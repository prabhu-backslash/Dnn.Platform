const path = require("path");
const settings = require("../../../../../settings.local.json");

module.exports = (env, argv) => {
    const isProduction = argv.mode === "production";
    return {
        entry: "./index",
        optimization: {
            minimize: true,
        },
        output: {
            path:
        isProduction || settings.WebsitePath == ""
            ? path.resolve(
                "../../../../Dnn.PersonaBar.Extensions/admin/personaBar/Dnn.Sites/scripts/exportables/Sites"
            )
            : path.join(
                settings.WebsitePath,
                "DesktopModules\\Admin\\Dnn.PersonaBar\\Modules\\Dnn.Sites\\scripts\\exportables\\Sites\\"
            ),
            filename: "SitesListView.js",
            publicPath: isProduction ? "" : "http://localhost:8050/dist/",
        },
        module: {
            rules: [
                {
                    test: /\.(js|jsx)$/,
                    enforce: "pre",
                    exclude: /node_modules/,
                    use: [
                        {
                            loader: "eslint-loader",
                            options: { fix: true },
                        }
                    ],
                },
                {
                    test: /\.(js|jsx)$/,
                    exclude: /node_modules/,
                    use: [
                        {
                            loader: "babel-loader",
                            options: {
                                presets: ["@babel/preset-env", "@babel/preset-react"],
                                plugins: [
                                    "@babel/plugin-transform-react-jsx",
                                    "@babel/plugin-proposal-object-rest-spread",
                                ],
                            },
                        }
                    ],
                },
                {
                    test: /\.(less|css)$/,
                    use:["style-loader", "css-loader", "less-loader"],
                },
                {
                    test: /\.(d.ts)$/,
                    use:{
                        loader: "null-loader",
                    },
                },
            ],
        },
        externals: require("@dnnsoftware/dnn-react-common/WebpackExternals"),
        resolve: {
            extensions: [".js", ".json", ".jsx"],
            modules: [
                path.resolve(__dirname, "./src"),
                path.resolve(__dirname, "../"),
                path.resolve(__dirname, "node_modules"),
                path.resolve(__dirname, "../../node_modules"),
                path.resolve(__dirname, "../../../../../node_modules"),
            ],
            fallback: {
                fs: false,
            }
        },
    };
};
