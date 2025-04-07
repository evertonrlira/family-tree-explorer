import * as React from 'react';
import useGetAllFamilies from '../hooks/useGetAllFamilies';
import DropdownSelect from './DropdownSelect';

const FamilySelector = ({ setSelectedFamilyId }) => {
    let data = [];

    ({ data } = useGetAllFamilies());

    const dropdownItems = Array.isArray(data)
        ? data.map(family => ({
                label: `${family.name}'s Family`,
                value: family.id
            }))
        : [];

    return (
        <div className='w-full gap-2 flex flex-col'>
            <label>Select Family:</label>
            <DropdownSelect
                label={"Pick a Family"}
                options={dropdownItems}
                onChange={setSelectedFamilyId}
                allowFiltering={false}
            />
        </div>
    );
};

export default FamilySelector;
