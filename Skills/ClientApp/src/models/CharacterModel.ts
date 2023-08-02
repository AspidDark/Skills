import FileModel from "./FileModel"
import SkillModel from "./SkillModel"

export default interface CharacterModel {
    id?: string
    priority: number
    buildName: string
    startingDate: Date
    photoId?: string
    story?: string
    skills: SkillModel[]
    photo?: FileModel
}