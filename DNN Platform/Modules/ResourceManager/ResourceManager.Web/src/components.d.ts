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
    interface DnnActionCopyUrl {
        "items": Item[];
    }
    interface DnnActionCreateFolder {
        "parentFolderId": number;
    }
    interface DnnActionDeleteItems {
        "items": Item[];
    }
    interface DnnActionDownloadItem {
        "item": Item;
    }
    interface DnnActionEditItem {
        "item": Item;
    }
    interface DnnActionMoveItems {
        "items": Item[];
    }
    interface DnnActionUnlinkItems {
        "items": Item[];
    }
    interface DnnActionUploadFile {
        "parentFolderId": number;
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
    interface DnnRmDeleteItems {
        /**
          * The list of items to delete.
         */
        "items": Item[];
    }
    interface DnnRmEditFile {
        /**
          * The ID of the folder to edit.
         */
        "fileId": number;
    }
    interface DnnRmEditFolder {
        /**
          * The ID of the folder to edit.
         */
        "folderId": number;
    }
    interface DnnRmFileContextMenu {
        /**
          * The item that triggered this menu.
         */
        "item": Item;
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
        /**
          * Indicates if this item is the currently selected one.
         */
        "selectedFolder": FolderTreeItem;
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
    interface DnnRmMoveItems {
        /**
          * The list of items to delete.
         */
        "items": Item[];
    }
    interface DnnRmProgressBar {
        /**
          * Defines the max progress value.
         */
        "max": number;
        /**
          * Defines the current progress value.
         */
        "value": number;
    }
    interface DnnRmQueuedFile {
        /**
          * Whether to extract uploaded zip files.
         */
        "extract": boolean;
        /**
          * The file to upload.
         */
        "file": File;
        /**
          * Optionally limit the file types that can be uploaded.
         */
        "filter": string;
        /**
          * The validation code to use for uploads.
         */
        "validationCode": string;
    }
    interface DnnRmRightPane {
    }
    interface DnnRmStatusBar {
    }
    interface DnnRmTopBar {
    }
    interface DnnRmUnlinkItems {
        /**
          * The list of items to delete.
         */
        "items": Item[];
    }
    interface DnnRmUploadFile {
    }
}
declare global {
    interface HTMLDnnActionCopyUrlElement extends Components.DnnActionCopyUrl, HTMLStencilElement {
    }
    var HTMLDnnActionCopyUrlElement: {
        prototype: HTMLDnnActionCopyUrlElement;
        new (): HTMLDnnActionCopyUrlElement;
    };
    interface HTMLDnnActionCreateFolderElement extends Components.DnnActionCreateFolder, HTMLStencilElement {
    }
    var HTMLDnnActionCreateFolderElement: {
        prototype: HTMLDnnActionCreateFolderElement;
        new (): HTMLDnnActionCreateFolderElement;
    };
    interface HTMLDnnActionDeleteItemsElement extends Components.DnnActionDeleteItems, HTMLStencilElement {
    }
    var HTMLDnnActionDeleteItemsElement: {
        prototype: HTMLDnnActionDeleteItemsElement;
        new (): HTMLDnnActionDeleteItemsElement;
    };
    interface HTMLDnnActionDownloadItemElement extends Components.DnnActionDownloadItem, HTMLStencilElement {
    }
    var HTMLDnnActionDownloadItemElement: {
        prototype: HTMLDnnActionDownloadItemElement;
        new (): HTMLDnnActionDownloadItemElement;
    };
    interface HTMLDnnActionEditItemElement extends Components.DnnActionEditItem, HTMLStencilElement {
    }
    var HTMLDnnActionEditItemElement: {
        prototype: HTMLDnnActionEditItemElement;
        new (): HTMLDnnActionEditItemElement;
    };
    interface HTMLDnnActionMoveItemsElement extends Components.DnnActionMoveItems, HTMLStencilElement {
    }
    var HTMLDnnActionMoveItemsElement: {
        prototype: HTMLDnnActionMoveItemsElement;
        new (): HTMLDnnActionMoveItemsElement;
    };
    interface HTMLDnnActionUnlinkItemsElement extends Components.DnnActionUnlinkItems, HTMLStencilElement {
    }
    var HTMLDnnActionUnlinkItemsElement: {
        prototype: HTMLDnnActionUnlinkItemsElement;
        new (): HTMLDnnActionUnlinkItemsElement;
    };
    interface HTMLDnnActionUploadFileElement extends Components.DnnActionUploadFile, HTMLStencilElement {
    }
    var HTMLDnnActionUploadFileElement: {
        prototype: HTMLDnnActionUploadFileElement;
        new (): HTMLDnnActionUploadFileElement;
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
    interface HTMLDnnRmDeleteItemsElement extends Components.DnnRmDeleteItems, HTMLStencilElement {
    }
    var HTMLDnnRmDeleteItemsElement: {
        prototype: HTMLDnnRmDeleteItemsElement;
        new (): HTMLDnnRmDeleteItemsElement;
    };
    interface HTMLDnnRmEditFileElement extends Components.DnnRmEditFile, HTMLStencilElement {
    }
    var HTMLDnnRmEditFileElement: {
        prototype: HTMLDnnRmEditFileElement;
        new (): HTMLDnnRmEditFileElement;
    };
    interface HTMLDnnRmEditFolderElement extends Components.DnnRmEditFolder, HTMLStencilElement {
    }
    var HTMLDnnRmEditFolderElement: {
        prototype: HTMLDnnRmEditFolderElement;
        new (): HTMLDnnRmEditFolderElement;
    };
    interface HTMLDnnRmFileContextMenuElement extends Components.DnnRmFileContextMenu, HTMLStencilElement {
    }
    var HTMLDnnRmFileContextMenuElement: {
        prototype: HTMLDnnRmFileContextMenuElement;
        new (): HTMLDnnRmFileContextMenuElement;
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
    interface HTMLDnnRmMoveItemsElement extends Components.DnnRmMoveItems, HTMLStencilElement {
    }
    var HTMLDnnRmMoveItemsElement: {
        prototype: HTMLDnnRmMoveItemsElement;
        new (): HTMLDnnRmMoveItemsElement;
    };
    interface HTMLDnnRmProgressBarElement extends Components.DnnRmProgressBar, HTMLStencilElement {
    }
    var HTMLDnnRmProgressBarElement: {
        prototype: HTMLDnnRmProgressBarElement;
        new (): HTMLDnnRmProgressBarElement;
    };
    interface HTMLDnnRmQueuedFileElement extends Components.DnnRmQueuedFile, HTMLStencilElement {
    }
    var HTMLDnnRmQueuedFileElement: {
        prototype: HTMLDnnRmQueuedFileElement;
        new (): HTMLDnnRmQueuedFileElement;
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
    interface HTMLDnnRmUnlinkItemsElement extends Components.DnnRmUnlinkItems, HTMLStencilElement {
    }
    var HTMLDnnRmUnlinkItemsElement: {
        prototype: HTMLDnnRmUnlinkItemsElement;
        new (): HTMLDnnRmUnlinkItemsElement;
    };
    interface HTMLDnnRmUploadFileElement extends Components.DnnRmUploadFile, HTMLStencilElement {
    }
    var HTMLDnnRmUploadFileElement: {
        prototype: HTMLDnnRmUploadFileElement;
        new (): HTMLDnnRmUploadFileElement;
    };
    interface HTMLElementTagNameMap {
        "dnn-action-copy-url": HTMLDnnActionCopyUrlElement;
        "dnn-action-create-folder": HTMLDnnActionCreateFolderElement;
        "dnn-action-delete-items": HTMLDnnActionDeleteItemsElement;
        "dnn-action-download-item": HTMLDnnActionDownloadItemElement;
        "dnn-action-edit-item": HTMLDnnActionEditItemElement;
        "dnn-action-move-items": HTMLDnnActionMoveItemsElement;
        "dnn-action-unlink-items": HTMLDnnActionUnlinkItemsElement;
        "dnn-action-upload-file": HTMLDnnActionUploadFileElement;
        "dnn-resource-manager": HTMLDnnResourceManagerElement;
        "dnn-rm-actions-bar": HTMLDnnRmActionsBarElement;
        "dnn-rm-create-folder": HTMLDnnRmCreateFolderElement;
        "dnn-rm-delete-items": HTMLDnnRmDeleteItemsElement;
        "dnn-rm-edit-file": HTMLDnnRmEditFileElement;
        "dnn-rm-edit-folder": HTMLDnnRmEditFolderElement;
        "dnn-rm-file-context-menu": HTMLDnnRmFileContextMenuElement;
        "dnn-rm-files-pane": HTMLDnnRmFilesPaneElement;
        "dnn-rm-folder-context-menu": HTMLDnnRmFolderContextMenuElement;
        "dnn-rm-folder-list": HTMLDnnRmFolderListElement;
        "dnn-rm-folder-list-item": HTMLDnnRmFolderListItemElement;
        "dnn-rm-items-cardview": HTMLDnnRmItemsCardviewElement;
        "dnn-rm-items-listview": HTMLDnnRmItemsListviewElement;
        "dnn-rm-left-pane": HTMLDnnRmLeftPaneElement;
        "dnn-rm-move-items": HTMLDnnRmMoveItemsElement;
        "dnn-rm-progress-bar": HTMLDnnRmProgressBarElement;
        "dnn-rm-queued-file": HTMLDnnRmQueuedFileElement;
        "dnn-rm-right-pane": HTMLDnnRmRightPaneElement;
        "dnn-rm-status-bar": HTMLDnnRmStatusBarElement;
        "dnn-rm-top-bar": HTMLDnnRmTopBarElement;
        "dnn-rm-unlink-items": HTMLDnnRmUnlinkItemsElement;
        "dnn-rm-upload-file": HTMLDnnRmUploadFileElement;
    }
}
declare namespace LocalJSX {
    interface DnnActionCopyUrl {
        "items": Item[];
    }
    interface DnnActionCreateFolder {
        "parentFolderId"?: number;
    }
    interface DnnActionDeleteItems {
        "items": Item[];
    }
    interface DnnActionDownloadItem {
        "item": Item;
    }
    interface DnnActionEditItem {
        "item": Item;
    }
    interface DnnActionMoveItems {
        "items": Item[];
    }
    interface DnnActionUnlinkItems {
        "items": Item[];
    }
    interface DnnActionUploadFile {
        "parentFolderId"?: number;
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
    interface DnnRmDeleteItems {
        /**
          * The list of items to delete.
         */
        "items": Item[];
        /**
          * Fires when there is a possibility that some folders have changed. Can be used to force parts of the UI to refresh.
         */
        "onDnnRmFoldersChanged"?: (event: CustomEvent<void>) => void;
    }
    interface DnnRmEditFile {
        /**
          * The ID of the folder to edit.
         */
        "fileId": number;
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
    interface DnnRmFileContextMenu {
        /**
          * The item that triggered this menu.
         */
        "item": Item;
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
        /**
          * Fires when a folder is picked.
         */
        "onDnnRmFolderListFolderPicked"?: (event: CustomEvent<FolderTreeItem>) => void;
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
          * Fires when a folder is clicked.
         */
        "onDnnRmFolderListItemClicked"?: (event: CustomEvent<FolderTreeItem>) => void;
        /**
          * Fires when a context menu is opened for this item. Emits the folder ID.
         */
        "onDnnRmcontextMenuOpened"?: (event: CustomEvent<number>) => void;
        /**
          * The ID of the parent folder.
         */
        "parentFolderId": number;
        /**
          * Indicates if this item is the currently selected one.
         */
        "selectedFolder"?: FolderTreeItem;
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
    interface DnnRmMoveItems {
        /**
          * The list of items to delete.
         */
        "items": Item[];
        /**
          * Fires when there is a possibility that some folders have changed. Can be used to force parts of the UI to refresh.
         */
        "onDnnRmFoldersChanged"?: (event: CustomEvent<void>) => void;
    }
    interface DnnRmProgressBar {
        /**
          * Defines the max progress value.
         */
        "max"?: number;
        /**
          * Defines the current progress value.
         */
        "value"?: number;
    }
    interface DnnRmQueuedFile {
        /**
          * Whether to extract uploaded zip files.
         */
        "extract"?: boolean;
        /**
          * The file to upload.
         */
        "file": File;
        /**
          * Optionally limit the file types that can be uploaded.
         */
        "filter": string;
        /**
          * The validation code to use for uploads.
         */
        "validationCode": string;
    }
    interface DnnRmRightPane {
    }
    interface DnnRmStatusBar {
    }
    interface DnnRmTopBar {
    }
    interface DnnRmUnlinkItems {
        /**
          * The list of items to delete.
         */
        "items": Item[];
        /**
          * Fires when there is a possibility that some folders have changed. Can be used to force parts of the UI to refresh.
         */
        "onDnnRmFoldersChanged"?: (event: CustomEvent<void>) => void;
    }
    interface DnnRmUploadFile {
        /**
          * Fires when there is a possibility that some folders have changed. Can be used to force parts of the UI to refresh.
         */
        "onDnnRmFoldersChanged"?: (event: CustomEvent<void>) => void;
    }
    interface IntrinsicElements {
        "dnn-action-copy-url": DnnActionCopyUrl;
        "dnn-action-create-folder": DnnActionCreateFolder;
        "dnn-action-delete-items": DnnActionDeleteItems;
        "dnn-action-download-item": DnnActionDownloadItem;
        "dnn-action-edit-item": DnnActionEditItem;
        "dnn-action-move-items": DnnActionMoveItems;
        "dnn-action-unlink-items": DnnActionUnlinkItems;
        "dnn-action-upload-file": DnnActionUploadFile;
        "dnn-resource-manager": DnnResourceManager;
        "dnn-rm-actions-bar": DnnRmActionsBar;
        "dnn-rm-create-folder": DnnRmCreateFolder;
        "dnn-rm-delete-items": DnnRmDeleteItems;
        "dnn-rm-edit-file": DnnRmEditFile;
        "dnn-rm-edit-folder": DnnRmEditFolder;
        "dnn-rm-file-context-menu": DnnRmFileContextMenu;
        "dnn-rm-files-pane": DnnRmFilesPane;
        "dnn-rm-folder-context-menu": DnnRmFolderContextMenu;
        "dnn-rm-folder-list": DnnRmFolderList;
        "dnn-rm-folder-list-item": DnnRmFolderListItem;
        "dnn-rm-items-cardview": DnnRmItemsCardview;
        "dnn-rm-items-listview": DnnRmItemsListview;
        "dnn-rm-left-pane": DnnRmLeftPane;
        "dnn-rm-move-items": DnnRmMoveItems;
        "dnn-rm-progress-bar": DnnRmProgressBar;
        "dnn-rm-queued-file": DnnRmQueuedFile;
        "dnn-rm-right-pane": DnnRmRightPane;
        "dnn-rm-status-bar": DnnRmStatusBar;
        "dnn-rm-top-bar": DnnRmTopBar;
        "dnn-rm-unlink-items": DnnRmUnlinkItems;
        "dnn-rm-upload-file": DnnRmUploadFile;
    }
}
export { LocalJSX as JSX };
declare module "@stencil/core" {
    export namespace JSX {
        interface IntrinsicElements {
            "dnn-action-copy-url": LocalJSX.DnnActionCopyUrl & JSXBase.HTMLAttributes<HTMLDnnActionCopyUrlElement>;
            "dnn-action-create-folder": LocalJSX.DnnActionCreateFolder & JSXBase.HTMLAttributes<HTMLDnnActionCreateFolderElement>;
            "dnn-action-delete-items": LocalJSX.DnnActionDeleteItems & JSXBase.HTMLAttributes<HTMLDnnActionDeleteItemsElement>;
            "dnn-action-download-item": LocalJSX.DnnActionDownloadItem & JSXBase.HTMLAttributes<HTMLDnnActionDownloadItemElement>;
            "dnn-action-edit-item": LocalJSX.DnnActionEditItem & JSXBase.HTMLAttributes<HTMLDnnActionEditItemElement>;
            "dnn-action-move-items": LocalJSX.DnnActionMoveItems & JSXBase.HTMLAttributes<HTMLDnnActionMoveItemsElement>;
            "dnn-action-unlink-items": LocalJSX.DnnActionUnlinkItems & JSXBase.HTMLAttributes<HTMLDnnActionUnlinkItemsElement>;
            "dnn-action-upload-file": LocalJSX.DnnActionUploadFile & JSXBase.HTMLAttributes<HTMLDnnActionUploadFileElement>;
            "dnn-resource-manager": LocalJSX.DnnResourceManager & JSXBase.HTMLAttributes<HTMLDnnResourceManagerElement>;
            "dnn-rm-actions-bar": LocalJSX.DnnRmActionsBar & JSXBase.HTMLAttributes<HTMLDnnRmActionsBarElement>;
            "dnn-rm-create-folder": LocalJSX.DnnRmCreateFolder & JSXBase.HTMLAttributes<HTMLDnnRmCreateFolderElement>;
            "dnn-rm-delete-items": LocalJSX.DnnRmDeleteItems & JSXBase.HTMLAttributes<HTMLDnnRmDeleteItemsElement>;
            "dnn-rm-edit-file": LocalJSX.DnnRmEditFile & JSXBase.HTMLAttributes<HTMLDnnRmEditFileElement>;
            "dnn-rm-edit-folder": LocalJSX.DnnRmEditFolder & JSXBase.HTMLAttributes<HTMLDnnRmEditFolderElement>;
            "dnn-rm-file-context-menu": LocalJSX.DnnRmFileContextMenu & JSXBase.HTMLAttributes<HTMLDnnRmFileContextMenuElement>;
            "dnn-rm-files-pane": LocalJSX.DnnRmFilesPane & JSXBase.HTMLAttributes<HTMLDnnRmFilesPaneElement>;
            "dnn-rm-folder-context-menu": LocalJSX.DnnRmFolderContextMenu & JSXBase.HTMLAttributes<HTMLDnnRmFolderContextMenuElement>;
            "dnn-rm-folder-list": LocalJSX.DnnRmFolderList & JSXBase.HTMLAttributes<HTMLDnnRmFolderListElement>;
            "dnn-rm-folder-list-item": LocalJSX.DnnRmFolderListItem & JSXBase.HTMLAttributes<HTMLDnnRmFolderListItemElement>;
            "dnn-rm-items-cardview": LocalJSX.DnnRmItemsCardview & JSXBase.HTMLAttributes<HTMLDnnRmItemsCardviewElement>;
            "dnn-rm-items-listview": LocalJSX.DnnRmItemsListview & JSXBase.HTMLAttributes<HTMLDnnRmItemsListviewElement>;
            "dnn-rm-left-pane": LocalJSX.DnnRmLeftPane & JSXBase.HTMLAttributes<HTMLDnnRmLeftPaneElement>;
            "dnn-rm-move-items": LocalJSX.DnnRmMoveItems & JSXBase.HTMLAttributes<HTMLDnnRmMoveItemsElement>;
            "dnn-rm-progress-bar": LocalJSX.DnnRmProgressBar & JSXBase.HTMLAttributes<HTMLDnnRmProgressBarElement>;
            "dnn-rm-queued-file": LocalJSX.DnnRmQueuedFile & JSXBase.HTMLAttributes<HTMLDnnRmQueuedFileElement>;
            "dnn-rm-right-pane": LocalJSX.DnnRmRightPane & JSXBase.HTMLAttributes<HTMLDnnRmRightPaneElement>;
            "dnn-rm-status-bar": LocalJSX.DnnRmStatusBar & JSXBase.HTMLAttributes<HTMLDnnRmStatusBarElement>;
            "dnn-rm-top-bar": LocalJSX.DnnRmTopBar & JSXBase.HTMLAttributes<HTMLDnnRmTopBarElement>;
            "dnn-rm-unlink-items": LocalJSX.DnnRmUnlinkItems & JSXBase.HTMLAttributes<HTMLDnnRmUnlinkItemsElement>;
            "dnn-rm-upload-file": LocalJSX.DnnRmUploadFile & JSXBase.HTMLAttributes<HTMLDnnRmUploadFileElement>;
        }
    }
}
