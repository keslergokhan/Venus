import type { Config } from "tailwindcss";
const flowbiteReact = require("flowbite-react/plugin/tailwindcss");

const config: Config = {
    content: [
        "./src/**/*.{js,ts,jsx,tsx}",
        "./node_modules/flowbite-react/lib/esm/**/*.js",
        ".flowbite-react\\class-list.json"
    ],

    theme: {
        extend: {},
    },
    plugins: [require("flowbite/plugin"), flowbiteReact],
};

export default config;