[Setup]
AppName=MediaTekDocuments
AppVersion=1.0
DefaultDirName={pf}\MediaTekDocuments
DefaultGroupName=MediaTekDocuments
OutputDir=output

[Files]
Source: "bin\Release\MediaTekDocuments.exe"; DestDir: "{app}"
Source: "bin\Release\MediaTekDocuments.exe.config"; DestDir: "{app}"

[Code]
var
  ApiAuth: string;
  ApiPage: TInputQueryWizardPage;

procedure InitializeWizard();
begin
  ApiPage := CreateInputQueryPage(
    wpWelcome,
    'Configuration API',
    'Authentification API',
    'Entrez les identifiants API (login:motdepasse)'
  );
  ApiPage.Add('Identifiants API :', False);
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  ConfigPath: string;
  Lines: TStringList;
  i: Integer;
  Line: string;
begin
  if CurStep = ssPostInstall then
  begin
    ApiAuth := ApiPage.Values[0];
    ConfigPath := ExpandConstant('{app}\MediaTekDocuments.exe.config');

    Lines := TStringList.Create;
    try
      Lines.LoadFromFile(ConfigPath);
      for i := 0 to Lines.Count - 1 do
      begin
        Line := Lines[i];
        StringChangeEx(Line, '__API_AUTH__', ApiAuth, True);
        Lines[i] := Line;
      end;
      Lines.SaveToFile(ConfigPath);
    finally
      Lines.Free;
    end;
  end;
end;

[Run]
Filename: "{app}\MediaTekDocuments.exe"; Description: "Lancer MediaTekDocuments"; Flags: nowait postinstall skipifsilent


