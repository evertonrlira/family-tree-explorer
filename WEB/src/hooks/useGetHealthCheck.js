import axios from 'axios';
import { useQuery } from '@tanstack/react-query';
import AppSettings from '@/config/settings';

const useGetHealthCheck = () => {
    const getHealthCheck = async () => {
        const requestConfig = {
            headers: {
                'x-client-id': AppSettings.API_CLIENT_ID,
            }
        };
        const { data } = await axios.get(AppSettings.API_BASE_URL + '/health', requestConfig);
        return data;
    }

    return useQuery({
        queryKey: ['getHealthCheck'],
        queryFn: getHealthCheck,
        cacheTime: 0,
    });
}

export default useGetHealthCheck;