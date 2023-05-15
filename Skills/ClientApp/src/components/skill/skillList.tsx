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
  const [title, setTitle] = useState('')
  const [subHeadline, setSubHeadline] = useState('')
  const [id, setId] = useState('')
  const [isActive, setIsActive] = useState(false)
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
    image: undefined
  }])

  const setOrderedItems = (newItems: SkillModel[]) => {
    const orderedItems = _.sortBy(newItems, 'priority')
    setItems(orderedItems)
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
    })
    for (let i = 0; i < newItems.length; i++) {
      newItems[i].priority = i
    }
    setOrderedItems(newItems)
  }

  const addItem = () => {
    const newitems = [...items, {
        id: v4(),
        createDate: new Date(),
        editDate: new Date(),
        ownerId:'ownerId',
        skillName:'skillName',
        level:1,
        skillPictureId: 'skillPictureId',
        isMain:1,
        image: undefined,
        priority: items.length
    }]
    setOrderedItems(newitems)
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

  const validateInput = async (skillId: number | '', id: string) => {

  }

  return (<>
        <DraggableList items={items} onDragEnd={onDragEnd} setValue={setItem} deleteValue={deleteItem} addItem={addItem} validateInput={validateInput}/>
  </>)
}
