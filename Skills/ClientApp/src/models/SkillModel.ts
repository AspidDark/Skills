import SkillImageModel from "./SkillImageModel"

export default interface SkillModel
{
    id:string
    priority: number
    skillName: string
    level: number
    isMain: number
    type: string
    image: SkillImageModel
}

