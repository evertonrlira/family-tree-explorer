import axios from 'axios';
import { useQuery } from '@tanstack/react-query';
import AppSettings from '@/config/settings';

const useGetFamilyMembers = (familyId) => {
    const getFamilyMembers = async ({ queryKey }) => {
        const [_, familyId] = queryKey;

        if (!familyId) {
            return [];
        }

        const requestConfig = {
            params: {
                familyId: familyId
            },
            headers: {
                'x-client-id': AppSettings.API_CLIENT_ID,
            }
        };
        const { data } = await axios.get(AppSettings.API_BASE_URL + '/family/members', requestConfig);
        return data;
    }

    return useQuery({
        queryKey: ['getFamilyMembers', familyId],
        queryFn: getFamilyMembers
    });
}

export default useGetFamilyMembers;