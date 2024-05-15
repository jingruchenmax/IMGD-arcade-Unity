
mergeInto(LibraryManager.library, {
  CheckIsArcadeMachine: function () {
    return new URLSearchParams(window.location.search).get("arcade") != null;
  },
});
