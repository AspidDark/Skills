import axios, { AxiosResponse } from "axios";
import authService from '../components/api-authorization/AuthorizeService'

export interface RequestData {
    url:string,
    data: any,
}

export interface ResponseData{
    success:boolean,
    data:any
}

class CRUDRequestHelper{
    
        async getRequest (request:string) : Promise<ResponseData>{
            try{
                let headers = await this.getHeaders();
                const responseJson = await axios.get(request, 
                    {headers:headers});
                    const result = this.validateResponse(responseJson)
                    return result
    
             }catch (ex) {
                console.log(ex);
                return  this.errorObject();
            }
        }

    async postRequest (request:RequestData, authorize:boolean = true) : Promise<ResponseData>{
        try{
            let headers = {};
            if(authorize){
               headers=await this.getHeaders();
               if(!headers){
                return this.errorObject('Auth')
               }
            }

            const responseJson = await axios.post(request.url, request.data,
                authorize ? {headers:headers}:undefined);
                const result = this.validateResponse(responseJson)
                return result

        }catch (ex) {
            console.log(ex);
            return  this.errorObject();
        }
    }

    async deleteRequest (request:string, authorize:boolean = true) : Promise<ResponseData>{
        try{
            let headers = {};
            if(authorize){
               headers=await this.getHeaders();
               if(!headers){
                return this.errorObject('Auth')
               }
            }

            const responseJson = await axios.delete(request, 
                authorize ? {headers:headers}:undefined);
                const result = this.validateResponse(responseJson)
                return result

        }catch (ex) {
            console.log(ex);
            return  this.errorObject();
        }
    }

    async updateRequest (request:RequestData, authorize:boolean = true) : Promise<ResponseData>{
        try{
            let headers = {};
            if(authorize){
               headers=await this.getHeaders();
               if(!headers){
                return this.errorObject('Auth')
               }
            }

            const responseJson = await axios.put(request.url, request.data, 
                authorize ? {headers:headers}:undefined);
                const result = this.validateResponse(responseJson)
                return result

        }catch (ex) {
            console.log(ex);
            return  this.errorObject();
        }
    }

    private validateResponse(responseJson: AxiosResponse<any>):ResponseData {
        if(!responseJson){
            return this.errorObject();
        }
        if(responseJson.status === 401){
            return this.errorObject('Auth')
        }
        if(!responseJson.data){
            return this.errorObject(responseJson.data)
        }
        return {success:true, data:responseJson.data}
    }

    private errorObject(message:string='Error'):ResponseData {
        return {
            success: false,
            data:message
        }
    }

    async getToken(): Promise<string|null>{
        const token = await authService.getAccessToken();
        if(!token){
            return null;
        }
        return `Bearer ${token}`;
    }

    async getHeaders():Promise<any>{
        const token:string|null= await this.getToken();
        if(!token){
            return null;
        }
        const headers ={
            'Authorization':token
        }
        return headers;
    }
}

export default CRUDRequestHelper;