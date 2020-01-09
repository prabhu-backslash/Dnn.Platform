﻿/* eslint-disable no-undef */
/* eslint-disable spellcheck/spell-checker */
const webpack = require("webpack");
const path = require("path");
const packageJson = require("./package.json");
const isProduction = process.env.NODE_ENV === "production";
let settings = null;
try {
    settings = require("../../../settings.local.json");
} catch (error) {
    // eslint-disable-next-line no-console
    console.log(error);
}

module.exports = {
    entry: "./src/main.jsx",
    optimization: {
        minimize: isProduction
    },
    output: {
        path: isProduction || (settings && settings.WebsitePath === "")
            ? path.resolve("../../Library/Dnn.PersonaBar.UI/admin/personaBar/scripts/exports/")
            : settings.WebsitePath + "\\DesktopModules\\Admin\\Dnn.PersonaBar\\scripts\\exports\\",
        filename: "export-bundle.js",
        publicPath: isProduction ? "" : "http://localhost:8070/dist/"
    },
    devServer: {
        disableHostCheck: !isProduction
    },
    module: {
        rules:[
            { test: /\.(js|jsx)$/, enforce: "pre", exclude: /node_modules/, loader: "eslint-loader", options: { fix: true } },
            { test: /\.(js|jsx)$/ , exclude: /node_modules/, loader: "babel-loader" },
            { test: /\.(less|css)$/, loader: "style-loader!css-loader!less-loader" },
            { test: /\.woff(2)?(\?v=[0-9].[0-9].[0-9])?$/, loader: "url-loader?mimetype=application/font-woff" },
            { test: /\.(ttf|eot|svg)(\?v=[0-9].[0-9].[0-9])?$/, loader: "file-loader?name=[name].[ext]" },
            { test: /\.(gif|png)$/, loader: "url-loader?mimetype=image/png" }
        ]
    },
    resolve: {
        extensions: [".js", ".json", ".jsx"],
        modules: [
            "node_modules",
            path.resolve("../../../node_modules"),
            path.resolve(__dirname, "src"),
            path.resolve(__dirname), "../Dnn.React.Common/src"
        ]
    },
    plugins: isProduction ? [
        new webpack.DefinePlugin({
            VERSION: JSON.stringify(packageJson.version),
            "process.env": {
                "NODE_ENV": JSON.stringify("production")
            }
        })
    ] : [
        new webpack.DefinePlugin({
            VERSION: JSON.stringify(packageJson.version)
        })
    ]
};
