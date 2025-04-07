import * as React from 'react';
import useGetFamilyMembers from '../hooks/useGetFamilyMembers';
import DropdownSelect from './DropdownSelect';

const PersonSelector = ({ selectedFamilyId, setSelectedPersonId }) => {
    const { data, isFetched } = useGetFamilyMembers(selectedFamilyId);

    const dropdownItems = Array.isArray(data)
        ? data.map(person => ({
            label: person.display,
            value: person.id
            }))
        : [];

    return (
        (selectedFamilyId.length === 0) ?
            (
                <div className="text-gray-500">
                    Please select a family first.
                </div>
            ) :
            (
                isFetched ?
                    (
                    <div className='w-full gap-2 flex flex-col'>
                        <label>Select Person:</label>
                        <DropdownSelect
                            label={"Pick a Person"}
                            options={dropdownItems}
                            onChange={setSelectedPersonId}
                        />
                    </div>
                    ) :
                    (
                        <div className="text-gray-500">
                            Loading...
                        </div>
                    )
            )
    );
};

export default PersonSelector;
