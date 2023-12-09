import SkillResponse from "./SkillResponse"

export default interface SkillSetResponse {
    id: string
    isDefault: boolean
    name: string
    skills: SkillResponse[]
}