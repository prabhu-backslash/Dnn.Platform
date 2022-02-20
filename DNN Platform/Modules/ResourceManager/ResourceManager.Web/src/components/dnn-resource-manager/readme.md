# dnn-resource-manager



<!-- Auto Generated Below -->


## Properties

| Property                | Attribute   | Description | Type     | Default     |
| ----------------------- | ----------- | ----------- | -------- | ----------- |
| `moduleId` _(required)_ | `module-id` |             | `number` | `undefined` |


## Dependencies

### Depends on

- [dnn-rm-top-bar](../dnn-rm-top-bar)
- dnn-vertical-splitview
- [dnn-rm-left-pane](../dnn-rm-left-pane)
- [dnn-rm-right-pane](../dnn-rm-right-pane)

### Graph
```mermaid
graph TD;
  dnn-resource-manager --> dnn-rm-top-bar
  dnn-resource-manager --> dnn-vertical-splitview
  dnn-resource-manager --> dnn-rm-left-pane
  dnn-resource-manager --> dnn-rm-right-pane
  dnn-rm-top-bar --> dnn-searchbox
  dnn-rm-left-pane --> dnn-rm-folder-list
  dnn-rm-folder-list --> dnn-rm-folder-list-item
  dnn-rm-folder-list-item --> dnn-treeview-item
  dnn-rm-folder-list-item --> dnn-rm-folder-list-item
  dnn-treeview-item --> dnn-collapsible
  dnn-rm-right-pane --> dnn-rm-actions-bar
  dnn-rm-right-pane --> dnn-rm-files-pane
  dnn-rm-right-pane --> dnn-rm-status-bar
  dnn-rm-actions-bar --> dnn-vertical-overflow-menu
  style dnn-resource-manager fill:#f9f,stroke:#333,stroke-width:4px
```

----------------------------------------------

*Built with [StencilJS](https://stenciljs.com/)*