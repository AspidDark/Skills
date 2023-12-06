import * as React from 'react'
import DraggableListItem from './DraggableListItem'
import {
  DragDropContext,
  Droppable,
  OnDragEndResponder
} from 'react-beautiful-dnd'
import Skill from '../../models/Skill'
import SkillLevel from '../../models/SkillLevel'

export interface DraggableListProps {
  items: Skill[]
  skillLevels: SkillLevel[]
  onDragEnd: OnDragEndResponder
  setValue: (value: string, id: string) => void
  deleteValue: (id: string) => void
  addItem: () => void
  changeSkillLevel: (value:boolean, id: string) => void
  onImageButtonClick : (id:string, level: number) => void
}

const DraggableList = React.memo(({ items, skillLevels, onDragEnd, setValue, deleteValue, addItem, changeSkillLevel, onImageButtonClick }: DraggableListProps) => {

  const getSkillLevel = (skill:Skill):SkillLevel =>{
    const result = skillLevels.filter(x=>x.skillId===skill.id && x.level===skill.level)[0]
    return result
  }

  const getUsedItemsLength =():number =>{
    const usedItems = items.filter(x=>x.isUsed)
    return usedItems.length
  }

  return (
    <DragDropContext onDragEnd={onDragEnd}>
      <Droppable droppableId="droppable-list">
        {provided => (
          <div ref={provided.innerRef} {...provided.droppableProps}>
            {items.map((item, index) => (
              item.isUsed && <DraggableListItem
                item={item}
                skillLevel={getSkillLevel(item)}
                index={index}
                key={item.id}
                setSkillName={setValue}
                deleteValue={deleteValue}
                addItem={addItem}
                isLast={getUsedItemsLength() - 1 === index}
                itemsLength={getUsedItemsLength()}
                changeSkillLevel={changeSkillLevel}
                onImageButtonClick={onImageButtonClick}
                />
            ))}
            {provided.placeholder}
          </div>
        )}
      </Droppable>
    </DragDropContext>
  )
})

export default DraggableList
