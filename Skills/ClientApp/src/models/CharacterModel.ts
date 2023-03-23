import { BaseModel } from "./BaseModel"
import FileModel from "./FileModel"
import SkillModel from "./SkillModel"

export default interface CharacterModel extends BaseModel {
    priority: number
    buildName: string
    startingDate: Date
    photoId?: string
    story?: string
    skills: Array<SkillModel>
    photo: FileModel
}