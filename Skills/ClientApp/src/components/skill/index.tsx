import React, { useState, useEffect } from 'react'
import { useTheme } from '@emotion/react'
import makeStyles from '@material-ui/core/styles/makeStyles'
import { DropResult } from 'react-beautiful-dnd'
import DraggableList from '../DraggabeList/DraggableList'
import { reorder } from '../DraggabeList/helpers'
import './styles.css'
import { v4 } from 'uuid'
import _ from 'lodash'
import SkillModel from '../../models/SkillModel'
import TextField from '@mui/material/TextField'
import dayjs, { Dayjs } from 'dayjs'
import { DemoContainer } from '@mui/x-date-pickers/internals/demo'
import { LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { DatePicker } from '@mui/x-date-pickers/DatePicker'

import Modal from '@mui/material/Modal';
import Typography from '@mui/material/Typography'

import ImageUpload from "./ImageUpload"
import { getRandomImage, getSameForOtherLevel, getByLevel, getStartingSkillImage } from '../../services/ImageService'
import Box from '@mui/material/Box/Box'
import { modalSelector } from '../modal/modalSelector'
import SkillImageModel from '../../models/SkillImageModel'
import { Grid } from '@mui/material'
import CharacterModel from '../../models/CharacterModel'
import {postCharacter } from '../../ApiServices/charecterApiSerice'
import Button from '@mui/material/Button';

const style = {
  position: 'absolute' as 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width:650,
  height:'flex',
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

const useStyles = makeStyles({
  flexPaper: {
    flex: 1,
    margin: 16,
    minWidth: 350
  },
  root: {
    display: 'flex',
    flexWrap: 'wrap'
  }
})

const startingImageType = 'eag'

export default function SkillList () {
  const theme: any = useTheme()
  const classes = useStyles()
  const [name, setName] = useState('')
  const [startDate, setStartDate] = React.useState<Dayjs | null>(dayjs('2022-04-17'));
  const [skillPointCount, setskillPointCount] = useState(1)
  const [existingImages, setExistingImages] = useState<string[]>([startingImageType])
  const [unusedImages, setUnusedImages] = useState<SkillImageModel[]>()
  const [modalHeight, setModalHeight ] = useState(770)

  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const [imageIdToChange, setImageIdToChange] = useState('')

  const [items, setItems] = useState<SkillModel[]>([{
    id: v4(),
    priority:0,
    skillName:'skillName',
    level:1,
    isMain:1,
    type:startingImageType,
    image: getStartingSkillImage(startingImageType)
  }])

  const setOrderedItems = (newItems: SkillModel[]) => {
    const orderedItems = _.sortBy(newItems, 'priority')
    setChangedItems(orderedItems)
  }

  const setItem = (value: string, id: string) => {
    const newItems = items.map(x => {
      if (x.id === id) {
        x.skillName = value
      }
      return x
    })
    setOrderedItems(newItems)
  }

  const deleteItem = (id: string) => {
    const newItems = items.filter(x => {
      if (x.id !== id) {
        return x
      }
      setskillPointCount(skillPointCount+x.level)
    })
    for (let i = 0; i < newItems.length; i++) {
      newItems[i].priority = i
    }
    setOrderedItems(newItems)
  }

  const addItem = () => {
    if(skillPointCount >= 1){
      const newImage = getRandomImage(existingImages)

      const newitems = [...items, {
        id: v4(),
        createDate: new Date(),
        editDate: new Date(),
        ownerId:'ownerId',
        skillName:'skillName',
        level:1,
        skillPictureId: 'skillPictureId',
        isMain:1,
        type: newImage.type,
        image: newImage,
        priority: items.length,
      }]
      setOrderedItems(newitems)
      setskillPointCount(skillPointCount-1)
    }
  }

  const onDragEnd = ({ destination, source }: DropResult) => {
    // dropped outside the list
    if (!destination) return
    const newItems = reorder(items, source.index, destination.index)
    for (let i = 0; i < newItems.length; i++) {
      newItems[i].priority = i
    }
    setOrderedItems(newItems)
  }

  const setStartDateValue =(value: Dayjs | null) => {
    setStartDate(value)
    if(!value){
      return
    }
    const now = new Date();
    const nowYear=now.getFullYear();
    const startYear = value.year()
    let skillPointCount = nowYear - startYear

    let newItems = new Array<SkillModel>()

    for (let item of items)
    {
      if(skillPointCount - item.level >=0 ) {
        skillPointCount -= item.level
        newItems.push(item)
        continue
      }
      break
    }

    const firstItem =items[0]
    
    if(newItems.length===0) {
      newItems = [{
        id: firstItem.id,
        priority:1,
        skillName:firstItem.skillName,
        level:1,
        isMain:1,
        type: firstItem.image.type,
        image: firstItem.image
      }]
      
    }
    setOrderedItems(newItems)
    setskillPointCount(skillPointCount)
  }

  const setChangedItems = (value: SkillModel[]) =>{
    setUsedImageTypes(value)
    setItems(value)
  }

  const changeSkillLevelValue = (value:boolean, id: string):void =>{
    var newItems = items.map(x=>{
      if(x.id === id) {
        if(value){
          if(skillPointCount>=1)
          {
            x.level++
            x.image = getSameForOtherLevel(x.image.id, true)
            setskillPointCount(skillPointCount-1)
            return x
          }
          return x
        }
        x.level--
        x.image = getSameForOtherLevel(x.image.id, false)
        setskillPointCount(skillPointCount+1)
        return x
      }
      return x
    })
    setOrderedItems(newItems)
  }

  const setUsedImageTypes = (skillModels:SkillModel[]) =>{
    const usedImages = skillModels.map(x=>x.image.type)
    setExistingImages(usedImages)
  }

const onImageButtonClick = (id:string, level: number, type:string) =>{
  const imagesOfSameLevel = getByLevel(level)
  const newUnusedImages = imagesOfSameLevel.filter(x=>{
    if(!existingImages.some(y => y===x.type)){
      return x
    }
  })
  setImageIdToChange(id)
  setUnusedImages(newUnusedImages)
  handleOpen()
}

const changeImage = (newSkillModel:SkillImageModel) => {
  const newItems = items.map(x=> {
    if(x.image.id === imageIdToChange){
      x.image = newSkillModel 
    }
    return x
  })
  setChangedItems(newItems)
  handleClose()
}

const changeModalSize = () =>{
  if(items.length >= 8 ){
    setModalHeight(530)
    return
  }
  if(items.length >= 3){
    setModalHeight(650)
    return
  }
  setModalHeight(770)
}

const saveCharacter = async () =>{
  let startDateValue = startDate?.toDate()
  if(!startDateValue) {
    startDateValue=new Date()
  }

  const saveModel: CharacterModel ={
    priority : 1,
    buildName : name,
    startingDate: startDateValue,
    skills: items
  }

  const result= await postCharacter(saveModel)
}

  useEffect(()=>{
    changeModalSize()
    if(items[0]){
      const imagesOfSameLevel = getByLevel(items[0].level)
      const newUnusedImages = imagesOfSameLevel.filter(x=>{
        if(!existingImages.some(y => y===x.type)){
          return x
        }
      })
      setUnusedImages(newUnusedImages)
    }
  },[])

  useEffect(() => {
    changeModalSize()
  }, [items]);

  const galleryImageList = [
    "https://raw.githubusercontent.com/dxyang/StyleTransfer/master/style_imgs/mosaic.jpg",
    "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg/1280px-Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg",
    "https://raw.githubusercontent.com/ShafeenTejani/fast-style-transfer/master/examples/dora-maar-picasso.jpg",
    "https://pbs.twimg.com/profile_images/925531519858257920/IyYLHp-u_400x400.jpg",
    "https://raw.githubusercontent.com/ShafeenTejani/fast-style-transfer/master/examples/dog.jpg",
    "http://r.ddmcdn.com/s_f/o_1/cx_462/cy_245/cw_1349/ch_1349/w_720/APL/uploads/2015/06/caturday-shutterstock_149320799.jpg"
  ];

  return (<>
  <Button
  onClick={() => saveCharacter()}
>
  Click me
</Button>
    <Box sx={{ flexGrow: 1 }}>
      <Grid container spacing={1}>
        <Grid item xs={2}>
          <ImageUpload cardName="Input Image" imageGallery={galleryImageList} />
        </Grid>
        <Grid item xs={5}>
          <TextField id="standard-basic" label="Name" variant="standard" value={name} onChange={e=>setName(e.target.value)}/>
        </Grid>
        <Grid item xs={4}>
        <LocalizationProvider dateAdapter={AdapterDayjs}>
          <DemoContainer components={['DatePicker', 'DatePicker']}>
            <DatePicker
              label="Starting date"
              value={startDate}
              onChange={(newValue) => setStartDateValue(newValue)}
            />
          </DemoContainer>
        </LocalizationProvider>
        </Grid>
        <Grid item xs={1}>
          Points {skillPointCount}
        </Grid>
      </Grid>
    </Box>
  <DraggableList 
    items={items} 
    onDragEnd={onDragEnd} 
    setValue={setItem} 
    deleteValue={deleteItem} 
    addItem={addItem}
    changeSkillLevel={changeSkillLevelValue}
    onImageButtonClick={onImageButtonClick}
    />
    <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
      <Box sx={{...style, height:modalHeight}}>
          <Typography id="modal-modal-title" variant="h6" component="h2">
          {modalSelector(unusedImages, changeImage)}
          </Typography>
        </Box>
      </Modal>
  </>)
}
