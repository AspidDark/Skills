import React, { useState, useEffect } from 'react'
import { Draggable } from 'react-beautiful-dnd'
import makeStyles from '@material-ui/core/styles/makeStyles'
import ListItem from '@material-ui/core/ListItem'
import ButtonBases from './skillImage'
import TextField from '@mui/material/TextField'
import IconButton from '@mui/material/IconButton'
import RemoveCircleOutlineIcon from '@mui/icons-material/RemoveCircleOutline'
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline'
import Box from '@mui/material/Box'
import { SkillLevelSelector } from '../DraggabeList/SkillLevalSelector'
import Skill from '../../models/Skill'
import SkillLevel from '../../models/SkillLevel'

const useStyles = makeStyles({
  draggingListItem: {
    background: 'rgb(235,235,235)'
  }
})

export interface DraggableListItemProps {
  item: Skill
  skillLevel: SkillLevel
  index: number
  setSkillName: (value: string, id: string) => void
  deleteValue: (id: string) => void
  addItem: () => void
  isLast: boolean
  itemsLength: number,
  changeSkillLevel: (value:boolean, id: string) => void
  onImageButtonClick : (id:string, level: number) => void
}

const DraggableListItem = ({ item, skillLevel, index, setSkillName, deleteValue, addItem, isLast, itemsLength, changeSkillLevel, onImageButtonClick }: DraggableListItemProps) => {
  const classes = useStyles()

  const [skillText, setSkillText] = useState<string>(item.customName?? item.name)

  const deleteItem = (skillId: string) => {
    if (itemsLength > 1) {
      deleteValue(skillId)
    }
  }

  const addListItem = () => {
    if (itemsLength >= 8) {
      return
    }
    addItem()
  }

  const setSkillTextVlue =(value:string) => {
    item.customName = value
    setSkillText(value),
    setSkillName(value, item.id)
  }

  const changeSkillLevelValue  = (value:boolean) => {
    changeSkillLevel(value, item.id)
  }

  return (
    <Draggable draggableId={item.id} index={index}>
      {(provided, snapshot) => (
        <ListItem
          ref={provided.innerRef}
          {...provided.draggableProps}
          {...provided.dragHandleProps}
          className={snapshot.isDragging ? classes.draggingListItem : ''}
        >
          <Box
            sx={{ display: 'flex' }}
          >
          <Box sx={{ width: '50' }}>
          {ButtonBases(skillLevel, onImageButtonClick)}
          </Box>
          <SkillLevelSelector currentSkillLevel={item.level} changeSkillValue={changeSkillLevelValue}></SkillLevelSelector>
          <Box sx={{ width: '800', minWidth: 800 }}>
          <TextField id="standard-basic" label="Skill" variant="standard" value={skillText}
                                            onChange={e => setSkillTextVlue(e.target.value)}/>
          </Box>
          <Box sx={{ width: '50' }}>
          <IconButton onClick={_ => deleteItem(item.id)}> <RemoveCircleOutlineIcon fontSize="large" /></IconButton>
          </Box>
          <Box width={50} sx={{ width: '50px' }}>
             {isLast && itemsLength < 8  && <IconButton onClick={_ => addListItem()}> <AddCircleOutlineIcon fontSize="large" /></IconButton>}
          </Box>
          <Box sx={{ width: '500' }}>
          </Box>
        </Box>
        </ListItem>
      )}
    </Draggable>
  )
}

export default DraggableListItem
