
mergeInto(LibraryManager.library, {
  CheckIsArcadeMachine: function () {
    return (globalThis.isArcadeMachine == true) || (parent.isArcadeMachine == true);
  },
});
