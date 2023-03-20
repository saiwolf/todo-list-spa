import { createBrowserRouter, Route, RouterProvider, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './_components';
import './custom.css';

const baseUrl = import.meta.env.BASE_URL;

let router = createBrowserRouter([
  {
    path: "/",
    Component: Layout,
    children: AppRoutes,
  }
], {
  basename: baseUrl!
});

if (import.meta.hot) {
  import.meta.hot.dispose(() => router.dispose());
}

export default function App() {
  return <RouterProvider router={router} fallbackElement={<Fallback />} />;
}

export function Fallback() {
  return <p>Performing initial data load</p>;
}
