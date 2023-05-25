import FileModel from '../models/FileModel'
import SkillImageModel from '../models/SkillImageModel'

const images: SkillImageModel[] =
[
    {
        id:'1',
        level: 2,
        type: 'air',
        url:'Heroes_III_AirMagicAdvanced.jpg',
        title:'123',
        width:'',
    },
    {
        id:'2',
        level: 1,
        type: 'air',
        url:'Heroes_III_AirMagicBasic.jpg',
        title:'1234',
        width:'',
    },
    {
        id:'3',
        level: 3,
        type: 'air',
        url:'Heroes_III_AirMagicExpert.jpg',
        title:'12345',
        width:'',
    },
    {
        id:'4',
        level: 2,
        type: 'arch',
        url:'Heroes_III_ArcheryAdvanced.jpg',
        title:'12',
        width:'',
    },
    {
        id:'5',
        level: 1,
        type: 'arch',
        url:'Heroes_III_ArcheryBasic.jpg',
        title:'21',
        width:'',
    },
    {
        id:'6',
        level: 3,
        type: 'arch',
        url:'Heroes_III_ArcheryExpert.jpg',
        title:'31',
        width:'',
    },
    {
        id:'7',
        level: 2,
        type: 'arm',
        url:'Heroes_III_ArmorerAdvanced.jpg',
        title:'13',
        width:'',
    },
    {
        id:'8',
        level: 1,
        type: 'arm',
        url:'Heroes_III_ArmorerBasic.jpg',
        title:'34',
        width:'',
    },
    {
        id:'9',
        level: 3,
        type: 'arm',
        url:'Heroes_III_ArmorerExpert.jpg',
        title:'43',
        width:'',
    },
    {
        id:'10',
        level: 2,
        type: 'art',
        url:'Heroes_III_ArtilleryAdvanced.jpg',
        title:'56',
        width:'',
    },
    {
        id:'11',
        level: 1,
        type: 'art',
        url:'Heroes_III_ArtilleryBasic.jpg',
        title:'65',
        width:'',
    },
    {
        id:'12',
        level: 3,
        type: 'art',
        url:'Heroes_III_ArtilleryExpert.jpg',
        title:'55',
        width:'',
    },
    {
        id:'13',
        level: 2,
        type: 'bal',
        url:'Heroes_III_BallisticsAdvanced.jpg',
        title:'66',
        width:'',
    },
    {
        id:'14',
        level: 1,
        type: 'bal',
        url:'Heroes_III_BallisticsBasic.jpg',
        title:'67',
        width:'',
    },
    {
        id:'15',
        level: 3,
        type: 'bal',
        url:'Heroes_III_BallisticsExpert.jpg',
        title:'76',
        width:'',
    },
    {
        id:'16',
        level: 2,
        type: 'dip',
        url:'Heroes_III_DiplomacyAdvanced.jpg',
        title:'89',
        width:'',
    },
    {
        id:'17',
        level: 1,
        type: 'dip',
        url:'Heroes_III_DiplomacyBasic.jpg',
        title:'98',
        width:'',
    },
    {
        id:'18',
        level: 3,
        type: 'dip',
        url:'Heroes_III_DiplomacyExpert.jpg',
        title:'88',
        width:'',
    },
]

export let getAll = ():SkillImageModel[] => {
    return images
}

export const getById = (id:string):SkillImageModel => {
    let result = images.find(x=>x.id==id)
    if(!result){
        result = images[0];
    }
    return result
}

export const getRandomImage = ():FileModel =>{
    const randomImageNumber = getRandomInt(images.length)
    const randomImage = images[randomImageNumber]
    const fileModel:FileModel ={
        id: randomImage.id,
        path: randomImage.url,
        ownerId:'',
        editDate:new Date(),
        createDate:new Date()
    }
    return fileModel
}

export let getByType = (type:string):SkillImageModel[] => {
    const result = images.filter(x=>x.type===type)
    return result
}

let  getRandomInt = (max: number) => {
    return Math.floor(Math.random() * max);
  }
