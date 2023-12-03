import SkillLevelsInfoResponse from "./SkillLevelsInfoResponse"

export default interface SkillResponse
{
    id:string
    isDefault: boolean
    defaultName: string
    description?: string
    skillLevelsData: SkillLevelsInfoResponse[]
}
