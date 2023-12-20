import CRUDRequestHelper from '../services/CRUDRequestHelper'
import * as path from '../Consts/PathConsts';
import CharacterResponseModel from '../models/ResponseModels/CharacterResponse';
import CharacterRequest from '../models/RequestModels/CharacterRequest';

    const uri:string='https://localhost:7256/api/v1/character';

    export interface BaseDto<T>{
        result:boolean,
        data:T
    }
    export const getCharacter = async(entityId?:string) :Promise<CharacterResponseModel|string> => {
        const apiService = new CRUDRequestHelper();
        let path = uri
        if(entityId) {
            path= uri+`?entityId=${entityId}`;
        }
        const resultApi=await apiService.getRequest(path);
        return resultApi.data;
    }

    export const postCharacter = async(entity:CharacterRequest):Promise<CharacterResponseModel|string> => {

        const apiService = new CRUDRequestHelper();
        const resultApi = await apiService.postRequest({url:uri, data: entity});
        return resultApi.data;
    }

    export const  deleteCharacter = async(entityId:string):Promise<CharacterResponseModel|string> => {
        const path= uri+`/${entityId}`;
        const apiService = new CRUDRequestHelper();
        const resultApi = await apiService.deleteRequest(path);
        if(!resultApi.success){
            return resultApi.data
        }
        return resultApi.data;
    }

    export const updateCharacter = async(updateEntity:CharacterRequest):Promise<CharacterResponseModel|string> =>{
        const path=uri+`/${updateEntity.id}`;
        const apiService = new CRUDRequestHelper();
        const resultApi = await apiService.updateRequest({url:path, data:updateEntity});
        return resultApi.data;
    }

    export const postDraftCharacter = async(entity:CharacterRequest):Promise<CharacterResponseModel|string> => {

        const apiService = new CRUDRequestHelper();
        const resultApi = await apiService.postRequest({url:`${uri}draft`, data: entity}, false);
        return resultApi.data;
    }

 

