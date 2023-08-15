import FileModel from "../FileModel"
import SkillResponseModel from "./SkillResponseModel"

export default interface CharacterResponseModel {
    id?: string
    priority: number
    buildName: string
    startingDate: Date
    photoId?: string
    story?: string
    skills: SkillResponseModel[]
    photo?: FileModel
}