import SkillsRequestModel from "./SkillsRequestModel"

export default interface CharacterRequestModel {
    priority: number
    buildName: string
    startingDate: Date
    photoId?: string
    story?: string
    skills: Array<SkillsRequestModel>

}