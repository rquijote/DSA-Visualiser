import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
    plugins: [react()],
    server: {
        // https://www.geeksforgeeks.org/reactjs/how-to-configure-proxy-in-vite/
        proxy: { // Set up proxy to handle requests to different backends.
            '/api': { // on /api it will proxy to the following: 
                target: 'http://localhost:5297', // Our backend port.
                changeOrigin: true, // Changes the Origin header to match target server.
                rewrite: path => path.replace(/^\/api/, ''), // Modifies the request path before forwarding.
            },
        },
    },
})
