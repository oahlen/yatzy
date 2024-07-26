{
  description = "Simple yatzy app built with ASP.NET and Svelte";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-24.05";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = {
    self,
    nixpkgs,
    flake-utils,
  }:
    flake-utils.lib.eachDefaultSystem (
      system: let
        pkgs = import nixpkgs {inherit system;};
      in {
        devShells.default = pkgs.mkShell {
          buildInputs = with pkgs; [
            (with dotnetCorePackages;
              combinePackages [
                sdk_8_0
                sdk_6_0
              ])
            netcoredbg
            omnisharp-roslyn
            nodejs_20
            nodePackages.npm
            nodePackages.typescript-language-server
            nodePackages.svelte-language-server
          ];
        };
      }
    );
}
