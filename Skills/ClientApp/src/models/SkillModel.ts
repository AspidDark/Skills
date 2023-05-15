import { BaseModel } from "./BaseModel"
import FileModel from "./FileModel"

export default interface SkillModel extends BaseModel
{
    priority: number
    skillName: string
    level: number
    skillPictureId: string
    isMain: number
    image?: FileModel
}

