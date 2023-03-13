import axios from "axios"
export default class PostService {

    static async getAll() {
        const response = await axios.get('https://localhost:7065/api/Comics/getAll')
        return response;
    } 
}