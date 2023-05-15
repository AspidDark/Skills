import React, { useState, useEffect } from 'react'
import { Draggable } from 'react-beautiful-dnd'
import SkillModel from '../../models/SkillModel'
import makeStyles from '@material-ui/core/styles/makeStyles'
import ListItem from '@material-ui/core/ListItem'
import ListItemAvatar from '@material-ui/core/ListItemAvatar'
import ListItemText from '@material-ui/core/ListItemText'
import Avatar from '@material-ui/core/Avatar'
import InboxIcon from '@material-ui/icons/Inbox'
import TextField from '@mui/material/TextField'
import IconButton from '@mui/material/IconButton'
import RemoveCircleOutlineIcon from '@mui/icons-material/RemoveCircleOutline'
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline'
import Box from '@mui/material/Box'

const useStyles = makeStyles({
  draggingListItem: {
    background: 'rgb(235,235,235)'
  }
})

export interface DraggableListItemProps {
  item: SkillModel
  index: number
  setValue: (value: string, id: string) => void
  deleteValue: (id: string) => void
  addItem: () => void
  isLast: boolean
  validateInput: (skillId: number | '', id: string) => void
  itemsLength: number
}

const DraggableListItem = ({ item, index, setValue, deleteValue, addItem, isLast, validateInput, itemsLength }: DraggableListItemProps) => {
  const classes = useStyles()

  const [skillText, setSkillText] = useState<string>('')

  const deleteItem = (itemId: string) => {
    if (itemsLength > 1) {
      deleteValue(itemId)
    }
  }

  const addListItem = () => {
    if (itemsLength >= 20) {
      return
    }
    addItem()
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
          <ListItemAvatar>
            <Avatar>
              <InboxIcon />
            </Avatar>
          </ListItemAvatar>
          </Box>
          <Box sx={{ width: '500', minWidth: 500 }}>
          <TextField id="outlined-basic" label="Skill name" variant="outlined" value={skillText}
                                            onChange={e => setSkillText(e.target.value)}/>
          </Box>
          <Box sx={{ width: '50' }}>
          <IconButton onClick={_ => deleteItem(item.id)}> <RemoveCircleOutlineIcon fontSize="large" /></IconButton>
          </Box>
          <Box width={50} sx={{ width: '50px' }}>
             {isLast && <IconButton onClick={_ => addListItem()}> <AddCircleOutlineIcon fontSize="large" /></IconButton>}
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
