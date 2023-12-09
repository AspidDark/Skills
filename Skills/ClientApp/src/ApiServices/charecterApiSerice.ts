import CRUDRequestHelper from '../services/CRUDRequestHelper'
import * as path from '../Consts/PathConsts';
import CharacterResponseModel from '../models/ResponseModels/CharacterResponse';
import CharacterRequest from '../models/RequestModels/CharacterRequest';

    const uri:string='https://localhost:7256/api/v1/character';

    export interface BaseDto<T>{
        result:boolean,
        data:T
    }
    export const getCharacter = async(entityId?:string) :Promise<CharacterResponseModel> => {
        const apiService = new CRUDRequestHelper();
        let path = uri
        if(entityId) {
            path= uri+`?entityId=${entityId}`;
        }
        const resultApi=await apiService.getRequest(path, false);
        return resultApi.data;
    }

  /*   async getParagraphs(pagination:PaginatonWithMainEntity):Promise<BaseDto<ParagraphDto[]>|BaseDto<string>>{
        const apiService = new CRUDRequestHelper();
        const path=this.uri+`s?pageNumber=${pagination.pageNumber}&pageSize=${pagination.pageSize}&topicId=${pagination.mainEntityId}`;
        const resultApi=await apiService.getRequest(path);
        if(!resultApi.success){
            let errorResult:BaseDto<string>={
                result:false,
                data:resultApi.data
            }
            return errorResult;
        }
        let resultBody:ParagraphDto[]=resultApi.data.map((x: any)=>this.mapToParagraph(x));

        let response:BaseDto<ParagraphDto[]>={
            result:true,
            data:resultBody
        }
        return response;
    }
    */

export const postCharacter = async(entity:CharacterRequest):Promise<CharacterResponseModel> => {

        const apiService = new CRUDRequestHelper();
        const resultApi = await apiService.postRequest({url:uri, data: entity}, false);
        return resultApi.data;
    }

  /*  async deleteParagraph(entityId:string):Promise<BaseDto<string>>{
        const path=this.uri+`/${entityId}`;
        const apiService = new CRUDRequestHelper();
        const resultApi = await apiService.deleteRequest(path);
        if(!resultApi||!resultApi.success){
            let errorResult:BaseDto<string>={
                result:false,
                data:resultApi.data
            }
            return errorResult;
        }
        let result:BaseDto<string>={
            result:true,
            data:resultApi.data
        }
        return result;
    }
  */
    export const updateCharacter = async(updateEntity:CharacterRequest):Promise<CharacterResponseModel> =>{
        const path=uri+`/${updateEntity.id}`;
        const apiService = new CRUDRequestHelper();
        const resultApi = await apiService.updateRequest({url:path, data:updateEntity}, false);
        return resultApi.data;
    }

 

