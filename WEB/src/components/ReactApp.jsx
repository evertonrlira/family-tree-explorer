import * as React from 'react';
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import SelectorMenu from './SelectorMenu';

export const ReactApp = () => {
    const queryClient = new QueryClient();

    return (
        <QueryClientProvider client={queryClient}>
            <SelectorMenu />
        </QueryClientProvider>
    );
};

export default ReactApp;