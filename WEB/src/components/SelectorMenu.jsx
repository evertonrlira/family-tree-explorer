import * as React from 'react';
import { useState } from 'react';
import FamilySelector from './FamilySelector';
import PersonSelector from './PersonSelector';
import useGetHealthCheck from '@/hooks/useGetHealthCheck';

const SelectorMenu = () => {
    const [selectedFamilyId, setSelectedFamilyId] = useState('');
    const [selectedPersonId, setSelectedPersonId] = useState('');
    const [isUnavailable, setIsUnavailable] = useState(true);

    try {
        const { isSuccess } = useGetHealthCheck();
        if (isSuccess && isUnavailable) {
            setIsUnavailable(isUnavailable => false);
        }
    } catch (error) {
        console.error("Error fetching health check:", error);
    }

    const handleFamilySelection = (value) => {
        if (value !== selectedFamilyId) {
            setSelectedFamilyId(value);
            setSelectedPersonId('');
        }
    }

    const handlePersonSelection = (value) => {
        setSelectedPersonId(value);
        console.log(value);
    }

    return (
        <>
            {
                isUnavailable ?
                (
                    <div className="text-red-500 text-center">
                        <p>The data provider system is not currently available</p>
                        <p>Please ensure it has been loaded and refresh this page</p>
                        <button onClick={() => history.go(0) } className='text-white bg-blue-700 hover:bg-blue-800 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 mt-4 cursor-pointer dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none'>Refresh Page</button>
                    </div>
                ) :
                (
                    <div className="gap-8 flex flex-col">
                        <FamilySelector
                            selectedFamilyId={selectedFamilyId}
                            setSelectedFamilyId={handleFamilySelection}
                        />
                        <PersonSelector
                            selectedFamilyId={selectedFamilyId}
                            setSelectedPersonId={handlePersonSelection}
                        />
                    </div>
                )
            }
        </>
    );
};

export default SelectorMenu;