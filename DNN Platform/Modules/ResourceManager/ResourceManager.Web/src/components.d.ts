/* eslint-disable */
/* tslint:disable */
/**
 * This is an autogenerated file created by the Stencil compiler.
 * It contains typing information for all components that exist in this project.
 */
import { HTMLStencilElement, JSXBase } from "@stencil/core/internal";
import { GetFolderContentResponse, Item } from "./services/ItemsClient";
import { FolderTreeItem } from "./services/InternalServicesClient";
export namespace Components {
    interface DnnActionCreateFolder {
        "parentFolderId": number;
    }
    interface DnnActionEditItem {
        "item": Item;
    }
    interface DnnResourceManager {
        /**
          * The ID of the module.
         */
        "moduleId": number;
    }
    interface DnnRmActionsBar {
    }
    interface DnnRmCreateFolder {
    }
    interface DnnRmEditFolder {
        /**
          * The ID of the folder to edit.
         */
        "folderId": number;
    }
    interface DnnRmFilesPane {
        /**
          * Defines how much more pixels to load under the fold.
         */
        "preloadOffset": number;
    }
    interface DnnRmFolderContextMenu {
        /**
          * The item that triggered this menu.
         */
        "item": Item;
    }
    interface DnnRmFolderList {
    }
    interface DnnRmFolderListItem {
        /**
          * If true, this node will be expanded on load.
         */
        "expanded": boolean;
        /**
          * The basic information about the folder
         */
        "folder": FolderTreeItem;
        /**
          * The ID of the parent folder.
         */
        "parentFolderId": number;
    }
    interface DnnRmItemsCardview {
        /**
          * The list of current items.
         */
        "currentItems": GetFolderContentResponse;
    }
    interface DnnRmItemsListview {
        /**
          * The list of current items.
         */
        "currentItems": GetFolderContentResponse;
    }
    interface DnnRmLeftPane {
    }
    interface DnnRmRightPane {
    }
    interface DnnRmStatusBar {
    }
    interface DnnRmTopBar {
    }
}
declare global {
    interface HTMLDnnActionCreateFolderElement extends Components.DnnActionCreateFolder, HTMLStencilElement {
    }
    var HTMLDnnActionCreateFolderElement: {
        prototype: HTMLDnnActionCreateFolderElement;
        new (): HTMLDnnActionCreateFolderElement;
    };
    interface HTMLDnnActionEditItemElement extends Components.DnnActionEditItem, HTMLStencilElement {
    }
    var HTMLDnnActionEditItemElement: {
        prototype: HTMLDnnActionEditItemElement;
        new (): HTMLDnnActionEditItemElement;
    };
    interface HTMLDnnResourceManagerElement extends Components.DnnResourceManager, HTMLStencilElement {
    }
    var HTMLDnnResourceManagerElement: {
        prototype: HTMLDnnResourceManagerElement;
        new (): HTMLDnnResourceManagerElement;
    };
    interface HTMLDnnRmActionsBarElement extends Components.DnnRmActionsBar, HTMLStencilElement {
    }
    var HTMLDnnRmActionsBarElement: {
        prototype: HTMLDnnRmActionsBarElement;
        new (): HTMLDnnRmActionsBarElement;
    };
    interface HTMLDnnRmCreateFolderElement extends Components.DnnRmCreateFolder, HTMLStencilElement {
    }
    var HTMLDnnRmCreateFolderElement: {
        prototype: HTMLDnnRmCreateFolderElement;
        new (): HTMLDnnRmCreateFolderElement;
    };
    interface HTMLDnnRmEditFolderElement extends Components.DnnRmEditFolder, HTMLStencilElement {
    }
    var HTMLDnnRmEditFolderElement: {
        prototype: HTMLDnnRmEditFolderElement;
        new (): HTMLDnnRmEditFolderElement;
    };
    interface HTMLDnnRmFilesPaneElement extends Components.DnnRmFilesPane, HTMLStencilElement {
    }
    var HTMLDnnRmFilesPaneElement: {
        prototype: HTMLDnnRmFilesPaneElement;
        new (): HTMLDnnRmFilesPaneElement;
    };
    interface HTMLDnnRmFolderContextMenuElement extends Components.DnnRmFolderContextMenu, HTMLStencilElement {
    }
    var HTMLDnnRmFolderContextMenuElement: {
        prototype: HTMLDnnRmFolderContextMenuElement;
        new (): HTMLDnnRmFolderContextMenuElement;
    };
    interface HTMLDnnRmFolderListElement extends Components.DnnRmFolderList, HTMLStencilElement {
    }
    var HTMLDnnRmFolderListElement: {
        prototype: HTMLDnnRmFolderListElement;
        new (): HTMLDnnRmFolderListElement;
    };
    interface HTMLDnnRmFolderListItemElement extends Components.DnnRmFolderListItem, HTMLStencilElement {
    }
    var HTMLDnnRmFolderListItemElement: {
        prototype: HTMLDnnRmFolderListItemElement;
        new (): HTMLDnnRmFolderListItemElement;
    };
    interface HTMLDnnRmItemsCardviewElement extends Components.DnnRmItemsCardview, HTMLStencilElement {
    }
    var HTMLDnnRmItemsCardviewElement: {
        prototype: HTMLDnnRmItemsCardviewElement;
        new (): HTMLDnnRmItemsCardviewElement;
    };
    interface HTMLDnnRmItemsListviewElement extends Components.DnnRmItemsListview, HTMLStencilElement {
    }
    var HTMLDnnRmItemsListviewElement: {
        prototype: HTMLDnnRmItemsListviewElement;
        new (): HTMLDnnRmItemsListviewElement;
    };
    interface HTMLDnnRmLeftPaneElement extends Components.DnnRmLeftPane, HTMLStencilElement {
    }
    var HTMLDnnRmLeftPaneElement: {
        prototype: HTMLDnnRmLeftPaneElement;
        new (): HTMLDnnRmLeftPaneElement;
    };
    interface HTMLDnnRmRightPaneElement extends Components.DnnRmRightPane, HTMLStencilElement {
    }
    var HTMLDnnRmRightPaneElement: {
        prototype: HTMLDnnRmRightPaneElement;
        new (): HTMLDnnRmRightPaneElement;
    };
    interface HTMLDnnRmStatusBarElement extends Components.DnnRmStatusBar, HTMLStencilElement {
    }
    var HTMLDnnRmStatusBarElement: {
        prototype: HTMLDnnRmStatusBarElement;
        new (): HTMLDnnRmStatusBarElement;
    };
    interface HTMLDnnRmTopBarElement extends Components.DnnRmTopBar, HTMLStencilElement {
    }
    var HTMLDnnRmTopBarElement: {
        prototype: HTMLDnnRmTopBarElement;
        new (): HTMLDnnRmTopBarElement;
    };
    interface HTMLElementTagNameMap {
        "dnn-action-create-folder": HTMLDnnActionCreateFolderElement;
        "dnn-action-edit-item": HTMLDnnActionEditItemElement;
        "dnn-resource-manager": HTMLDnnResourceManagerElement;
        "dnn-rm-actions-bar": HTMLDnnRmActionsBarElement;
        "dnn-rm-create-folder": HTMLDnnRmCreateFolderElement;
        "dnn-rm-edit-folder": HTMLDnnRmEditFolderElement;
        "dnn-rm-files-pane": HTMLDnnRmFilesPaneElement;
        "dnn-rm-folder-context-menu": HTMLDnnRmFolderContextMenuElement;
        "dnn-rm-folder-list": HTMLDnnRmFolderListElement;
        "dnn-rm-folder-list-item": HTMLDnnRmFolderListItemElement;
        "dnn-rm-items-cardview": HTMLDnnRmItemsCardviewElement;
        "dnn-rm-items-listview": HTMLDnnRmItemsListviewElement;
        "dnn-rm-left-pane": HTMLDnnRmLeftPaneElement;
        "dnn-rm-right-pane": HTMLDnnRmRightPaneElement;
        "dnn-rm-status-bar": HTMLDnnRmStatusBarElement;
        "dnn-rm-top-bar": HTMLDnnRmTopBarElement;
    }
}
declare namespace LocalJSX {
    interface DnnActionCreateFolder {
        "parentFolderId"?: number;
    }
    interface DnnActionEditItem {
        "item": Item;
    }
    interface DnnResourceManager {
        /**
          * The ID of the module.
         */
        "moduleId": number;
    }
    interface DnnRmActionsBar {
    }
    interface DnnRmCreateFolder {
        /**
          * Fires when there is a possibility that some folders have changed. Can be used to force parts of the UI to refresh.
         */
        "onDnnRmFoldersChanged"?: (event: CustomEvent<void>) => void;
    }
    interface DnnRmEditFolder {
        /**
          * The ID of the folder to edit.
         */
        "folderId": number;
        /**
          * Fires when there is a possibility that some folders have changed. Can be used to force parts of the UI to refresh.
         */
        "onDnnRmFoldersChanged"?: (event: CustomEvent<void>) => void;
    }
    interface DnnRmFilesPane {
        /**
          * Defines how much more pixels to load under the fold.
         */
        "preloadOffset"?: number;
    }
    interface DnnRmFolderContextMenu {
        /**
          * The item that triggered this menu.
         */
        "item": Item;
    }
    interface DnnRmFolderList {
    }
    interface DnnRmFolderListItem {
        /**
          * If true, this node will be expanded on load.
         */
        "expanded"?: boolean;
        /**
          * The basic information about the folder
         */
        "folder": FolderTreeItem;
        /**
          * Fires when a context menu is opened for this item. Emits the folder ID.
         */
        "onDnnRmcontextMenuOpened"?: (event: CustomEvent<number>) => void;
        /**
          * The ID of the parent folder.
         */
        "parentFolderId": number;
    }
    interface DnnRmItemsCardview {
        /**
          * The list of current items.
         */
        "currentItems": GetFolderContentResponse;
    }
    interface DnnRmItemsListview {
        /**
          * The list of current items.
         */
        "currentItems": GetFolderContentResponse;
    }
    interface DnnRmLeftPane {
    }
    interface DnnRmRightPane {
    }
    interface DnnRmStatusBar {
    }
    interface DnnRmTopBar {
    }
    interface IntrinsicElements {
        "dnn-action-create-folder": DnnActionCreateFolder;
        "dnn-action-edit-item": DnnActionEditItem;
        "dnn-resource-manager": DnnResourceManager;
        "dnn-rm-actions-bar": DnnRmActionsBar;
        "dnn-rm-create-folder": DnnRmCreateFolder;
        "dnn-rm-edit-folder": DnnRmEditFolder;
        "dnn-rm-files-pane": DnnRmFilesPane;
        "dnn-rm-folder-context-menu": DnnRmFolderContextMenu;
        "dnn-rm-folder-list": DnnRmFolderList;
        "dnn-rm-folder-list-item": DnnRmFolderListItem;
        "dnn-rm-items-cardview": DnnRmItemsCardview;
        "dnn-rm-items-listview": DnnRmItemsListview;
        "dnn-rm-left-pane": DnnRmLeftPane;
        "dnn-rm-right-pane": DnnRmRightPane;
        "dnn-rm-status-bar": DnnRmStatusBar;
        "dnn-rm-top-bar": DnnRmTopBar;
    }
}
export { LocalJSX as JSX };
declare module "@stencil/core" {
    export namespace JSX {
        interface IntrinsicElements {
            "dnn-action-create-folder": LocalJSX.DnnActionCreateFolder & JSXBase.HTMLAttributes<HTMLDnnActionCreateFolderElement>;
            "dnn-action-edit-item": LocalJSX.DnnActionEditItem & JSXBase.HTMLAttributes<HTMLDnnActionEditItemElement>;
            "dnn-resource-manager": LocalJSX.DnnResourceManager & JSXBase.HTMLAttributes<HTMLDnnResourceManagerElement>;
            "dnn-rm-actions-bar": LocalJSX.DnnRmActionsBar & JSXBase.HTMLAttributes<HTMLDnnRmActionsBarElement>;
            "dnn-rm-create-folder": LocalJSX.DnnRmCreateFolder & JSXBase.HTMLAttributes<HTMLDnnRmCreateFolderElement>;
            "dnn-rm-edit-folder": LocalJSX.DnnRmEditFolder & JSXBase.HTMLAttributes<HTMLDnnRmEditFolderElement>;
            "dnn-rm-files-pane": LocalJSX.DnnRmFilesPane & JSXBase.HTMLAttributes<HTMLDnnRmFilesPaneElement>;
            "dnn-rm-folder-context-menu": LocalJSX.DnnRmFolderContextMenu & JSXBase.HTMLAttributes<HTMLDnnRmFolderContextMenuElement>;
            "dnn-rm-folder-list": LocalJSX.DnnRmFolderList & JSXBase.HTMLAttributes<HTMLDnnRmFolderListElement>;
            "dnn-rm-folder-list-item": LocalJSX.DnnRmFolderListItem & JSXBase.HTMLAttributes<HTMLDnnRmFolderListItemElement>;
            "dnn-rm-items-cardview": LocalJSX.DnnRmItemsCardview & JSXBase.HTMLAttributes<HTMLDnnRmItemsCardviewElement>;
            "dnn-rm-items-listview": LocalJSX.DnnRmItemsListview & JSXBase.HTMLAttributes<HTMLDnnRmItemsListviewElement>;
            "dnn-rm-left-pane": LocalJSX.DnnRmLeftPane & JSXBase.HTMLAttributes<HTMLDnnRmLeftPaneElement>;
            "dnn-rm-right-pane": LocalJSX.DnnRmRightPane & JSXBase.HTMLAttributes<HTMLDnnRmRightPaneElement>;
            "dnn-rm-status-bar": LocalJSX.DnnRmStatusBar & JSXBase.HTMLAttributes<HTMLDnnRmStatusBarElement>;
            "dnn-rm-top-bar": LocalJSX.DnnRmTopBar & JSXBase.HTMLAttributes<HTMLDnnRmTopBarElement>;
        }
    }
}
