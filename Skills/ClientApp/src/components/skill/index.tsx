import React, { useState, useEffect } from 'react'
import { useTheme } from '@emotion/react'
import makeStyles from '@material-ui/core/styles/makeStyles'
import { DropResult } from 'react-beautiful-dnd'
import DraggableList from '../DraggabeList/DraggableList'
import { reorder } from '../DraggabeList/helpers'
import './styles.css'
import _, { forEach } from 'lodash'
import TextField from '@mui/material/TextField'
import dayjs, { Dayjs } from 'dayjs'
import { DemoContainer } from '@mui/x-date-pickers/internals/demo'
import { LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { DatePicker } from '@mui/x-date-pickers/DatePicker'
import Modal from '@mui/material/Modal';
import Typography from '@mui/material/Typography'
import ImageUpload from "./ImageUpload"
import {getImagepath } from '../../services/ImageService'
import Box from '@mui/material/Box/Box'
import { modalSelector } from '../modal/modalSelector'
import { Grid } from '@mui/material'
import {postCharacter, getCharacter, updateCharacter } from '../../ApiServices/charecterApiSerice'
import Button from '@mui/material/Button';
import CharacterResponseModel from '../../models/ResponseModels/CharacterResponse'
import Skill from '../../models/Skill'
import SkillLevel from '../../models/SkillLevel'
import CharacterRequest from '../../models/RequestModels/CharacterRequest'

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

export default function SkillList () {
  const theme: any = useTheme()
  const classes = useStyles()
  const [name, setName] = useState('')
  const [characterId, setCharacterId] = useState<string|undefined>('')
  const [skillSetId, setSkillSetId] = useState('')
  //proprity
  //buildName
  const [startDate, setStartDate] = React.useState<Dayjs | null>(dayjs('2022-04-17'));
  const [skillPointCount, setskillPointCount] = useState(1)

  const [skillLevels, setSkillLevels] = useState<SkillLevel[]>([])
  const [skills, setSkills] = useState<Skill[]>([])
  const [unusedLevelSkills, setUnusedLevelSkills] = useState<SkillLevel[]>([])

  const [modalHeight, setModalHeight ] = useState(770)
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const [skillIdToChange, setSkillIdToChange] = useState('')

  const baseSkillPoints = 1

  const setOrderedItems = (newItems:Skill[]) =>{
    const orderedItems = _.sortBy(newItems, 'priority')
    setSkills(orderedItems)
    const unusedItems = newItems.filter(x=>x.isUsed===false)
    changeModalSize(unusedItems.length)
  }

  
  //Draggable list
  const onDragEnd = ({ destination, source }: DropResult) => {
    // dropped outside the list
    if (!destination) return
    const newItems = reorder(skills, source.index, destination.index)
    for (let i = 0; i < newItems.length; i++) {
      newItems[i].priority = i
    }
    setOrderedItems(newItems)
  }

  const setItem = (value: string, id: string) => {
    const newItems = skills.map(x => {
      if (x.id === id) {
        x.customName=value
      }
      return x
    })
    setOrderedItems(newItems)
  }

  const deleteItem = (skillId: string) => {
    const skillToDelete = skills.filter(x=>x.id==skillId)[0]
    setskillPointCount(skillPointCount+skillToDelete.level+1)
    const skillsWithLowerPriority = skills.filter(x=>x.isUsed && x.priority > skillToDelete.priority)
    toUnused(skillId)
    if(skillsWithLowerPriority){
      skillsWithLowerPriority.forEach(x=>{
        x.priority--
      })
    }
    setOrderedItems(skills)
  }

  const addItem = () => {
    if(skillPointCount <= 0) {
      return;
    }
    const randomUnusedSkillId = getRandomUnusedSkillId()
    const usedSkills = skills.filter(x=>x.isUsed)
    toUsed(randomUnusedSkillId, 0, usedSkills.length)
    setskillPointCount(skillPointCount-1)
    setOrderedItems(skills)
  }
  
  const toUsed = (skillId: string, level: number, priorirty: number) => {
    const skill= skills.filter(x=>x.id===skillId)[0]
    skill.isUsed= true;
    skill.priority = priorirty,
    skill.level = level
  }

  const toUnused = (skillId: string)=>{
    const skill= skills.filter(x=>x.id===skillId)[0]
    skill.level = 0
    skill.priority = 10
    skill.isUsed = false
  }

  const getRandomUnusedSkillId = () : string =>{
    const unusedSkills = skills.filter(x =>x.isUsed===false)
    const randomSkillIndex = getRandomInt(unusedSkills.length)
    const result = unusedSkills[randomSkillIndex]
    return result.id
  }

  const getRandomInt = (max: number) => Math.floor(Math.random() * max);
  
  const setStartDateValue =(value: Dayjs | null, usedSkillPoints: number = 0) => {
    if(!value){
      return
    }
    setStartDate(value)
    const now = new Date();
    const nowYear = now.getFullYear();
    const startYear = value.year()
    let skillPointCount = nowYear - startYear + baseSkillPoints - usedSkillPoints
    
    const skillItems = skills.filter(x=>x.isUsed===true)
    if(skillItems.length === 1){
      if(skillItems[0].level+1 >= skillPointCount){
        skillItems[0].level = skillPointCount
      }
    }
    else{
      for (const item of skillItems)
      {
        if(skillPointCount - (item.level + 1) >= 0 ) {
          skillPointCount = skillPointCount - (item.level+1)
          continue
        }
        toUnused(item.id)
      }
    }
    setOrderedItems(skills)
    setskillPointCount(skillPointCount)
  }

  const changeSkillLevelValue = (up:boolean, skillId: string):void =>{
    const newItems = skills.map(x=>{
      if(x.id === skillId) {
        if(up){
          if(skillPointCount>=1) {
            const nextlevalValue = x.level+1
            x.level=nextlevalValue
            setskillPointCount(skillPointCount-1)
          } 
          return x
        }
        const previousLevel =  x.level-1
        x.level=previousLevel
        setskillPointCount(skillPointCount+1)
      }
      return x
    })
    setOrderedItems(newItems)
  }

  const onImageButtonClick = (skillId:string, level: number) =>{
    const sameLevelSkills = skillLevels.filter(x=>x.level===level)
    let unusedSkillLevels:SkillLevel[]=[]
    sameLevelSkills.forEach(x=>{
      if(skills.some(y=>y.id===x.skillId&& y.isUsed===false)){
        unusedSkillLevels.push(x)
      }
    })
    setUnusedLevelSkills(unusedSkillLevels)
    setSkillIdToChange(skillId)
    handleOpen()
  }

  const changeImage = (newSkillLevel:SkillLevel) => {
    if(newSkillLevel.skillId === skillIdToChange){
      return
    }
    const previousSkill = skills.filter(x => x.id === skillIdToChange)[0]
    const previousSkillLevel = previousSkill.level
    const previousSkillPriority = previousSkill.priority
    toUnused(skillIdToChange)
    const newSkill = skills.filter(x => x.id === newSkillLevel.skillId)[0]
    toUsed(newSkill.id, previousSkillLevel, previousSkillPriority)
    setOrderedItems(skills)
    handleClose()
  }

  const changeModalSize = (unusedItemsCount:number) =>{
    if(unusedItemsCount <= 20 ){
      setModalHeight(530)
      return
    }
    if(unusedItemsCount <= 25){
      setModalHeight(650)
      return
    }
    setModalHeight(770)
  }

//Crud
const saveCharacterRequest = async () =>{
  let startDateValue = startDate?.toDate()
  if(!startDateValue) {
    startDateValue=new Date()
  }

  const saveModel: CharacterRequest ={
    priority : 1,
    buildName : name,
    startingDate: startDateValue,
    skills: items
  }

  const result= await postCharacter(saveModel)
  setData(result);

}

const getCahracterRequest = async () =>{
  const response = await getCharacter()
  setData(response)
}

const updateCharacterRequest = async () =>{
 /* let startDateValue = startDate?.toDate()
  if(!startDateValue) {
    startDateValue=new Date()
  }

  const saveModel: CharacterRequest ={
    id: characterId,
    priority : 1,
    buildName : name,
    startingDate: startDateValue,
    skills: items
  }
  const response = await updateCharacter(saveModel)
  setData(response)
  */
}

const setData = (data: CharacterResponseModel): void => {
  setCharacterId(data.id)
  setSkillSetId(data.skillSet.id)
  // all skill with images
  let characterSkillsData : Skill[] = [];
  let skillLevels : SkillLevel[] =[]
  let usedSkillPoints:number = 0
  data.skillSet.skills.forEach( x=> {
    x.skillLevelsData.forEach(y=> {
      const imagePath = getImagepath(y.id)
      const skillLevel: SkillLevel = {
        id: y.id,
        path: imagePath,
        level: y.level,
        source: y.source,
        skillId: x.id,
      }
      skillLevels.push(skillLevel)
    })
    
    let characterSkillInfo : Skill = {
      id: x.id,
      name :x.defaultName,
      priority: 100,
      isUsed : false,
      isMain: 1,
      level:0
    }
    if(data.skills.some(y=> y.skillId === x.id)){
      const usedSkill =  data.skills.filter(y=> y.skillId === x.id)[0];
      characterSkillInfo.isMain = usedSkill.isMain
      characterSkillInfo.isUsed = true
      characterSkillInfo.isMain = usedSkill.isMain
      characterSkillInfo.level = usedSkill.level
      characterSkillInfo.priority = usedSkill.priority
      usedSkillPoints += usedSkill.level + 1
      if(usedSkill.customName){
        characterSkillInfo.name = usedSkill.customName
      }
    }
    characterSkillsData.push(characterSkillInfo)
  })

  setStartDateValue(dayjs(data.startingDate), usedSkillPoints)

  setSkillLevels(skillLevels)
  setOrderedItems(characterSkillsData)
}
  useEffect(()=>{
    getCahracterRequest()
  }, [])

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
  onClick={() => saveCharacterRequest()}
>
  Post
</Button>
<Button
  onClick={() => updateCharacterRequest()}
>
    Update
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
    items={skills}
    skillLevels={skillLevels}
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
          {modalSelector(unusedLevelSkills, changeImage)}
          </Typography>
        </Box>
      </Modal>
  </>)
}
