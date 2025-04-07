import axios from 'axios';
import { useQuery } from '@tanstack/react-query';
import AppSettings from '@/config/settings';

const useGetAllFamilies = () => {
    const getAllFamilies = async () => {
        const requestConfig = {
            headers: {
                'x-client-id': AppSettings.API_CLIENT_ID,
            }
        };
        const { data } = await axios.get(AppSettings.API_BASE_URL + '/family', requestConfig);
        return data;
    }

    return useQuery({
        queryKey: ['getAllFamilies'],
        queryFn: getAllFamilies
    });
}

export default useGetAllFamilies;