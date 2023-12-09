import FileModel from "../FileModel"
import SkillRequest from "./SkillRequest"

export default interface CharacterRequest {
    id?: string
    priority: number
    buildName: string
    startingDate: Date
    story?: string
    photoId?: string
    photo?: FileModel
    skillSetId:string
    skills: SkillRequest[]
}