import SkillImageModel from "./SkillImageModel"

export default interface SkillModel
{
    id:string
    priority: number
    skillName: string
    level: number
    skillPictureId: string
    isMain: number
    image: SkillImageModel
}

