import React, { useState, useEffect } from 'react'
import { useTheme } from '@emotion/react'
import makeStyles from '@material-ui/core/styles/makeStyles'
import { DropResult } from 'react-beautiful-dnd'
import DraggableList from '../DraggabeList/DraggableList'
import { reorder } from '../DraggabeList/helpers'
import './styles.css'
import { v4 } from 'uuid'
import _, { forIn } from 'lodash'
import SkillModel from '../../models/SkillModel'
import TextField from '@mui/material/TextField'
import TableCell from '@mui/material/TableCell'
import TableRow from '@mui/material/TableRow'
import dayjs, { Dayjs } from 'dayjs'
import { DemoContainer } from '@mui/x-date-pickers/internals/demo'
import { LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { DatePicker } from '@mui/x-date-pickers/DatePicker'
import Table from '@mui/material/Table'

import Modal from '@mui/material/Modal';
import Typography from '@mui/material/Typography'

import ImageUpload from "./ImageUpload"
import { getRandomImage, getSameForOtherLevel, getByLevel } from '../../services/ImageService'
import Box from '@mui/material/Box/Box'
import { Button } from '@mui/material'
import { modalSelector } from '../modal/modalSelector'
import SkillImageModel from '../../models/SkillImageModel'

const style = {
  position: 'absolute' as 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};
//https://codesandbox.io/s/vj1q68zm25?file=/src/ImageUpload.js

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

export default function SkillList () {
  const theme: any = useTheme()
  const classes = useStyles()
  const [name, setName] = useState('')
  const [startDate, setStartDate] = React.useState<Dayjs | null>(dayjs('2022-04-17'));
  const [skillPointCount, setskillPointCount] = useState(1)
  const [existingImages, setExistingImages] = useState<string[]>([''])
  const [unusedImages, setUnusedImages] = useState<SkillImageModel[]>()

  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const [imageIdToChange, setImageIdToChange] = useState('')

  const [items, setItems] = useState<SkillModel[]>([{
    id: v4(),
    createDate: new Date(),
    editDate: new Date(),
    ownerId:'ownerId',
    priority:1,
    skillName:'skillName',
    level:1,
    skillPictureId: 'skillPictureId',
    isMain:1,
    image: getRandomImage(existingImages)
  }])

  const setOrderedItems = (newItems: SkillModel[]) => {
    const orderedItems = _.sortBy(newItems, 'priority')
    setCahngedItems(orderedItems)
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
      const newitems = [...items, {
        id: v4(),
        createDate: new Date(),
        editDate: new Date(),
        ownerId:'ownerId',
        skillName:'skillName',
        level:1,
        skillPictureId: 'skillPictureId',
        isMain:1,
        image: getRandomImage(existingImages),
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
        createDate: firstItem.createDate,
        editDate: firstItem.editDate,
        ownerId:firstItem.ownerId,
        priority:1,
        skillName:firstItem.skillName,
        level:1,
        skillPictureId: firstItem.skillPictureId,
        isMain:1,
        image: firstItem.image
      }]
      
    }
    setCahngedItems(newItems)
    setskillPointCount(skillPointCount)
  }

  const setCahngedItems = (value: SkillModel[]) =>{
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
    setCahngedItems(newItems)
  }

  const setUsedImageTypes = (skillModels:SkillModel[]) =>{
    const usedImages = skillModels.map(x=>x.image.type)
    setExistingImages(usedImages)
  }

const onImageButtonClick = (id:string, level: number, type:string) =>{
  const imagesOfSameLevel = getByLevel(level)
  const unusedImages = imagesOfSameLevel.filter(x=>{
    if(!existingImages.some(y => y===x.type)){
      return x
    }
  })
  setImageIdToChange(id)
  setUnusedImages(unusedImages)
  handleOpen()
}

const changeImaage = (newSkillModel:SkillImageModel) => {
  const newItems = items.map(x=> {
    if(x.id === imageIdToChange){
      x.image = newSkillModel 
    }
    return x
  })
  setCahngedItems(newItems)
}


  useEffect(() => {
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
  <h4>{name}</h4>
  <ImageUpload cardName="Input Image" imageGallery={galleryImageList} />
  <TextField id="standard-basic" label="Name" variant="standard" value={name} onChange={e=>setName(e.target.value)}/>
    <Table>
      <TableRow>
        <TableCell align="left">
        <LocalizationProvider dateAdapter={AdapterDayjs}>
          <DemoContainer components={['DatePicker', 'DatePicker']}>
            <DatePicker
              label="Starting date"
              value={startDate}
              onChange={(newValue) => setStartDateValue(newValue)}
            />
          </DemoContainer>
        </LocalizationProvider>
        </TableCell>
        <TableCell align="right">
          Skill Points
        {skillPointCount}
        </TableCell>
      </TableRow>
    </Table>
  <DraggableList 
    items={items} 
    onDragEnd={onDragEnd} 
    setValue={setItem} 
    deleteValue={deleteItem} 
    addItem={addItem}
    changeSkillLevel={changeSkillLevelValue}
    onImageButtonClick={onImageButtonClick}
    />
    <Button onClick={handleOpen}>Open modal</Button>
    <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Typography id="modal-modal-title" variant="h6" component="h2">
          {modalSelector(unusedImages, changeImaage)}
          </Typography>
        </Box>
      </Modal>
  </>)
}
