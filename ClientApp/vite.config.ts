import { defineConfig } from 'vite'
import path from 'path';
import react from '@vitejs/plugin-react-swc'
import mkcert from 'vite-plugin-mkcert';

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react(), mkcert()],
  server: {
    port: 3000,
    https: true,
    strictPort: true,
    proxy: {
      '/api': {
        target: 'https://localhost:5001',
        changeOrigin: true,
        secure: false,
        rewrite: (path) => path.replace(/^\/api/, '/api'),
      }
    }
  },
  resolve: {
    alias: {
      "~bootstrap": path.resolve(__dirname, './node_modules/bootstrap'),
      "~bootstrap-icons": path.resolve(__dirname, './node_modules/bootstrap-icons'),
    }
  }
})
