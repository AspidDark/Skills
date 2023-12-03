import FileModel from "./FileModel"

export default interface CharacterModel {
    id?: string
    priority: number
    buildName: string
    startingDate: Date
    photoId?: string
    story?: string
    photo?: FileModel
}