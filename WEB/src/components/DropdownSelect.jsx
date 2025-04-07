import { useState, useRef, useEffect } from 'react';
import './DropdownSelect.css';

const DropdownSelect = ({ label, options, onChange, allowFiltering = true }) => {
    const [isOpen, setIsOpen] = useState(false);
    const [searchFilter, setSearchFilter] = useState('');
    const [selected, setSelected] = useState(null);
    const wrapperRef = useRef(null);

    useEffect(() => {
        const handleClickOutside = (event) => {
            if (wrapperRef.current && !wrapperRef.current.contains(event.target)) {
                setIsOpen(false);
            }
        };
        document.addEventListener('mousedown', handleClickOutside);
        return () =>
            document.removeEventListener('mousedown', handleClickOutside);
    }, []);

    const handleOptionClick = (option) => {
        setSelected(option);
        setIsOpen(false);
        onChange(option.value);
    };

    let filteredOptions = Array.isArray(options) ? options : [];
    if (allowFiltering) {
        filteredOptions = options.filter(option => option.label.toLowerCase().includes(searchFilter.toLowerCase()));
    }

    if (selected?.value && !filteredOptions.some(option => option.value === selected.value)) {
        setSelected(null);
    }

    return (
        <div ref={wrapperRef} className="relative w-full max-w-[500px]" data-testid="select-wrapper">
            <div
                onClick={() => setIsOpen(prev => !prev)}
                className="flex justify-between items-center p-2 border border-gray-300 rounded cursor-pointer bg-white transition duration-200 hover:border-[var(--hover)] focus-within:shadow-outline"
                data-testid="select-input"
            >
                <span data-testid="select-input-label">{selected ? selected.label : label}</span>
                <div id="dropdown-icon">
                    <svg
                        className={`w-4 h-4 transform transition-transform duration-200 ${isOpen ? 'rotate-180' : 'rotate-0'}`}
                        xmlns="http://www.w3.org/2000/svg"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                    >
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 9l-7 7-7-7" />
                    </svg>
                </div>
            </div>

            { isOpen && (
                <div className="absolute top-full left-0 mt-1 w-full max-h-[300px] bg-white border border-gray-200 rounded shadow-lg z-10 overflow-hidden"
                    data-testid="select-dropdown">
                    { allowFiltering && (
                        <div className="m-2" >
                            <input
                                type="text"
                                placeholder="Filter Results"
                                autoComplete="off"
                                value={searchFilter}
                                onChange={(e) => setSearchFilter(e.target.value)}
                                className="w-full p-2 border border-gray-300 rounded text-base focus:outline-none focus:border-blue-600"
                                data-testid="select-dropdown-filter-input"
                            />
                        </div>
                    )}
                    <ul className="m-0 p-0 list-none max-h-[240px] overflow-y-auto" data-testid="select-dropdown-options">
                        {filteredOptions.length > 0 ? (
                            filteredOptions.map((option) => (
                                <li
                                    key={option.value}
                                    value={option.value}
                                    onClick={() => handleOptionClick(option)}
                                    className={`p-2 cursor-pointer option-hover hover:bg-[var(--hover)]
                                        ${selected && selected.value === option.value ? 'bg-[var(--selected)]' : ''}`}
                                    data-testid={`select-dropdown-option-${option.value}`}
                                >
                                    {option.label}
                                </li>
                            ))
                        ) : (
                            <li key="no-options" className="p-2 text-gray-500 italic">
                                Nothing to display
                            </li>
                        )}
                    </ul>
                </div>
            )}
        </div>
    );
};

export default DropdownSelect;