import * as React from 'react'
import DraggableListItem from './DraggableListItem'
import {
  DragDropContext,
  Droppable,
  OnDragEndResponder
} from 'react-beautiful-dnd'
import SkillModel from '../../models/SkillModel'

export interface DraggableListProps {
  items: SkillModel[]
  onDragEnd: OnDragEndResponder
  setValue: (value: string, id: string) => void
  deleteValue: (id: string) => void
  addItem: () => void
  changeSkillLevel: (value:boolean, id: string) => void
  onImageButtonClick : (id:string, level: number, type:string) => void
}

const DraggableList = React.memo(({ items, onDragEnd, setValue, deleteValue, addItem, changeSkillLevel, onImageButtonClick }: DraggableListProps) => {
  return (
    <DragDropContext onDragEnd={onDragEnd}>
      <Droppable droppableId="droppable-list">
        {provided => (
          <div ref={provided.innerRef} {...provided.droppableProps}>
            {items.map((item, index) => (
              <DraggableListItem
                item={item}
                index={index}
                key={item.id}
                setSkillName={setValue}
                deleteValue={deleteValue}
                addItem={addItem}
                isLast={items.length - 1 === index}
                itemsLength={items.length}
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
