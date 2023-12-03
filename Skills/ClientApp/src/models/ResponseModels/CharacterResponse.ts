import FileModel from "../FileModel"
import CharacterSkillResponse from "./CharacterSkillResponse"
import SkillSetResponse from "./SkillSetResponse"

export default interface CharacterResponse {
    id?: string
    priority: number
    buildName: string
    startingDate: Date
    skills: CharacterSkillResponse[]
    story?: string
    photoId?: string
    photo?: FileModel
    skillSet: SkillSetResponse
}