import React from 'react';
import { render, fireEvent, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import DropdownSelect from './DropdownSelect';

const TEST_IDS = {
    container: "select-wrapper",
    input: "select-input",
    inputLabel: "select-input-label",
    dropdown: "select-dropdown",
    filter: "select-dropdown-filter-input",
    optionsContainer: "select-dropdown-options",
    optionPrefix: "select-dropdown-option-"
};

test('renders component correctly', () => {
    // Arrange
    const label = 'Test Label';
    const options = [
        { label: 'Option 1', value: '1' },
        { label: 'Option 2', value: '2' },
    ];
    const onChange = jest.fn();

    // Act
    render(<DropdownSelect label={label} options={options} onChange={onChange}  />);

    // Assert
    //  Check if the component is rendered
    const fetchedComponent = screen.getByTestId(TEST_IDS.container);
    expect(fetchedComponent).toBeInTheDocument();
    // Check if the placeholder is rendered correctly
    const fetchedLabel = screen.getByTestId(TEST_IDS.inputLabel);
    expect(fetchedLabel).toBeInTheDocument();
    expect(fetchedLabel).toHaveTextContent(label);
    // Check if the dropdown is closed initially
    const fetchedDropdown = screen.queryByTestId(TEST_IDS.dropdown);
    expect(fetchedDropdown).not.toBeInTheDocument();
});

test('component opens on click', () => {
    // Arrange
    const label = 'Test Label';
    const options = [
        { label: 'Option 1', value: '1' },
        { label: 'Option 2', value: '2' },
    ];
    const onChange = jest.fn();

    // Act
    render(<DropdownSelect label={label} options={options} onChange={onChange}  />);
    // Click on the input to open the dropdown
    fireEvent.click(screen.getByTestId(TEST_IDS.input));

    // Assert
    // Check if the dropdown is opened and elements are rendered
    const fetchedDropdown = screen.queryByTestId(TEST_IDS.dropdown);
    expect(fetchedDropdown).toBeInTheDocument();
    const fetchedOptionsContainer = screen.getByTestId(TEST_IDS.optionsContainer);
    expect(fetchedOptionsContainer).toBeInTheDocument();
    expect(fetchedOptionsContainer.childElementCount).toBe(options.length);
    expect(fetchedOptionsContainer.children[0].value.toString()).toBe(options[0].value);
    expect(fetchedOptionsContainer.children[0].textContent).toBe(options[0].label);
    expect(fetchedOptionsContainer.children[1].value.toString()).toBe(options[1].value);
    expect(fetchedOptionsContainer.children[1].textContent).toBe(options[1].label);
});

test('selecting an option changes label', () => {
    // Arrange
    const label = 'Test Label';
    const options = [
        { label: 'Option 1', value: '1' },
        { label: 'Option 2', value: '2' },
    ];
    const onChange = jest.fn();

    // Act
    render(<DropdownSelect label={label} options={options} onChange={onChange}  />);
    // Click on the input to open the dropdown
    fireEvent.click(screen.getByTestId(TEST_IDS.input));
    // Click on the second option
    fireEvent.click(screen.getByTestId(TEST_IDS.optionPrefix + options[1].value));

    // Assert
    // Check if the dropdown is closed
    const fetchedDropdown = screen.queryByTestId(TEST_IDS.dropdown);
    expect(fetchedDropdown).not.toBeInTheDocument();
    // Check if the second option is now rendered in the label
    const fetchedLabel = screen.getByTestId(TEST_IDS.inputLabel);
    expect(fetchedLabel).toBeInTheDocument();
    expect(fetchedLabel).toHaveTextContent(options[1].label);
});

test('filtering options works correctly', () => {
    // Arrange
    const label = 'Test Label';
    const options = [
        { label: 'Option 1', value: '1' },
        { label: 'Option 2', value: '2' },
        { label: 'Another Option', value: '3' },
    ];
    const onChange = jest.fn();

    // Act
    render(<DropdownSelect label={label} options={options} onChange={onChange} allowFiltering={true} />);
    // Click on the input to open the dropdown
    fireEvent.click(screen.getByTestId(TEST_IDS.input));
    // Type in the filter input
    fireEvent.change(screen.getByTestId(TEST_IDS.filter), { target: { value: 'Another' } });

    // Assert
    // Check if the filtered options are displayed correctly
    const fetchedOptionsContainer = screen.getByTestId(TEST_IDS.optionsContainer);
    expect(fetchedOptionsContainer.childElementCount).toBe(1);
});