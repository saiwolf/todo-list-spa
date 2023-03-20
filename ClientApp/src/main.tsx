import ReactDOM from 'react-dom/client'
import App from './App';
import ThemeContextWrapper from './_components/theme-context-wrapper';

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <ThemeContextWrapper>
    <App />
  </ThemeContextWrapper>
)
