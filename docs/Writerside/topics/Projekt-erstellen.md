# Projekte erstellen und einrichten

Um unser Projekt zu erstellen, nutzen wir die .NET CLI. Damit können wir schnell alles aufsetzen.

Als Erstes erstellen wir unseren Projektordner:

````
New-Item GymManagement -ItemType Directory
Set-Location GymManagement
````

## Standarddateien

Darin erstellen wir nun einige nötige Files, wie die Solution, das <path>Directory.Build.Props</path> File, das <path>.editorconfig</path> File 
und das <path>.gitignore</path> File.

````
dotnet new sln --name "GymManagement" 
New-Item Directory.Build.Props
New-Item .gitignore
New-Item .editorconfig
````

**<path>Directory.Build.Props</path>**

````XML
<Project>

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
      <PrivateAssets>All</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers</IncludeAssets>
    </PackageReference>
  </ItemGroup>

</Project>
````

> **Wichtig:** Passe die .NET- und die StyleCop-Version an!

Diese Datei dient dazu jegliche Redundanzen in unseren <path>.csproj</path> Files zu verhindern. Beispielsweise fügen wir hier für alle Projekte 
das NuGet-Paket StyleCop hinzu, welches unseren Code analysiert.

**<path>.gitignore</path>**

````
## Ignore Visual Studio temporary files, build results, and
## files generated by popular Visual Studio add-ons.
##
## Get latest from https://github.com/github/gitignore/blob/main/VisualStudio.gitignore

# User-specific files
*.rsuser
*.suo
*.user
*.userosscache
*.sln.docstates

# User-specific files (MonoDevelop/Xamarin Studio)
*.userprefs

# Mono auto generated files
mono_crash.*

# Build results
[Dd]ebug/
[Dd]ebugPublic/
[Rr]elease/
[Rr]eleases/
x64/
x86/
[Ww][Ii][Nn]32/
[Aa][Rr][Mm]/
[Aa][Rr][Mm]64/
bld/
[Bb]in/
[Oo]bj/
[Ll]og/
[Ll]ogs/

# Visual Studio 2015/2017 cache/options directory
.vs/
# Uncomment if you have tasks that create the project's static files in wwwroot
#wwwroot/

# Visual Studio 2017 auto generated files
Generated\ Files/

# MSTest test Results
[Tt]est[Rr]esult*/
[Bb]uild[Ll]og.*

# NUnit
*.VisualState.xml
TestResult.xml
nunit-*.xml

# Build Results of an ATL Project
[Dd]ebugPS/
[Rr]eleasePS/
dlldata.c

# Benchmark Results
BenchmarkDotNet.Artifacts/

# .NET Core
project.lock.json
project.fragment.lock.json
artifacts/

# ASP.NET Scaffolding
ScaffoldingReadMe.txt

# StyleCop
StyleCopReport.xml

# Files built by Visual Studio
*_i.c
*_p.c
*_h.h
*.ilk
*.meta
*.obj
*.iobj
*.pch
*.pdb
*.ipdb
*.pgc
*.pgd
*.rsp
*.sbr
*.tlb
*.tli
*.tlh
*.tmp
*.tmp_proj
*_wpftmp.csproj
*.log
*.tlog
*.vspscc
*.vssscc
.builds
*.pidb
*.svclog
*.scc

# Chutzpah Test files
_Chutzpah*

# Visual C++ cache files
ipch/
*.aps
*.ncb
*.opendb
*.opensdf
*.sdf
*.cachefile
*.VC.db
*.VC.VC.opendb

# Visual Studio profiler
*.psess
*.vsp
*.vspx
*.sap

# Visual Studio Trace Files
*.e2e

# TFS 2012 Local Workspace
$tf/

# Guidance Automation Toolkit
*.gpState

# ReSharper is a .NET coding add-in
_ReSharper*/
*.[Rr]e[Ss]harper
*.DotSettings.user

# TeamCity is a build add-in
_TeamCity*

# DotCover is a Code Coverage Tool
*.dotCover

# AxoCover is a Code Coverage Tool
.axoCover/*
!.axoCover/settings.json

# Coverlet is a free, cross platform Code Coverage Tool
coverage*.json
coverage*.xml
coverage*.info

# Visual Studio code coverage results
*.coverage
*.coveragexml

# NCrunch
_NCrunch_*
.*crunch*.local.xml
nCrunchTemp_*

# MightyMoose
*.mm.*
AutoTest.Net/

# Web workbench (sass)
.sass-cache/

# Installshield output folder
[Ee]xpress/

# DocProject is a documentation generator add-in
DocProject/buildhelp/
DocProject/Help/*.HxT
DocProject/Help/*.HxC
DocProject/Help/*.hhc
DocProject/Help/*.hhk
DocProject/Help/*.hhp
DocProject/Help/Html2
DocProject/Help/html

# Click-Once directory
publish/

# Publish Web Output
*.[Pp]ublish.xml
*.azurePubxml
# Note: Comment the next line if you want to checkin your web deploy settings,
# but database connection strings (with potential passwords) will be unencrypted
*.pubxml
*.publishproj

# Microsoft Azure Web App publish settings. Comment the next line if you want to
# checkin your Azure Web App publish settings, but sensitive information contained
# in these scripts will be unencrypted
PublishScripts/

# NuGet Packages
*.nupkg
# NuGet Symbol Packages
*.snupkg
# The packages folder can be ignored because of Package Restore
**/[Pp]ackages/*
# except build/, which is used as an MSBuild target.
!**/[Pp]ackages/build/
# Uncomment if necessary however generally it will be regenerated when needed
#!**/[Pp]ackages/repositories.config
# NuGet v3's project.json files produces more ignorable files
*.nuget.props
*.nuget.targets

# Microsoft Azure Build Output
csx/
*.build.csdef

# Microsoft Azure Emulator
ecf/
rcf/

# Windows Store app package directories and files
AppPackages/
BundleArtifacts/
Package.StoreAssociation.xml
_pkginfo.txt
*.appx
*.appxbundle
*.appxupload

# Visual Studio cache files
# files ending in .cache can be ignored
*.[Cc]ache
# but keep track of directories ending in .cache
!?*.[Cc]ache/

# Others
ClientBin/
~$*
*~
*.dbmdl
*.dbproj.schemaview
*.jfm
*.pfx
*.publishsettings
orleans.codegen.cs

# Including strong name files can present a security risk
# (https://github.com/github/gitignore/pull/2483#issue-259490424)
#*.snk

# Since there are multiple workflows, uncomment next line to ignore bower_components
# (https://github.com/github/gitignore/pull/1529#issuecomment-104372622)
#bower_components/

# RIA/Silverlight projects
Generated_Code/

# Backup & report files from converting an old project file
# to a newer Visual Studio version. Backup files are not needed,
# because we have git ;-)
_UpgradeReport_Files/
Backup*/
UpgradeLog*.XML
UpgradeLog*.htm
ServiceFabricBackup/
*.rptproj.bak

# SQL Server files
*.mdf
*.ldf
*.ndf

# Business Intelligence projects
*.rdl.data
*.bim.layout
*.bim_*.settings
*.rptproj.rsuser
*- [Bb]ackup.rdl
*- [Bb]ackup ([0-9]).rdl
*- [Bb]ackup ([0-9][0-9]).rdl

# Microsoft Fakes
FakesAssemblies/

# GhostDoc plugin setting file
*.GhostDoc.xml

# Node.js Tools for Visual Studio
.ntvs_analysis.dat
node_modules/

# Visual Studio 6 build log
*.plg

# Visual Studio 6 workspace options file
*.opt

# Visual Studio 6 auto-generated workspace file (contains which files were open etc.)
*.vbw

# Visual Studio 6 auto-generated project file (contains which files were open etc.)
*.vbp

# Visual Studio 6 workspace and project file (working project files containing files to include in project)
*.dsw
*.dsp

# Visual Studio 6 technical files
*.ncb
*.aps

# Visual Studio LightSwitch build output
**/*.HTMLClient/GeneratedArtifacts
**/*.DesktopClient/GeneratedArtifacts
**/*.DesktopClient/ModelManifest.xml
**/*.Server/GeneratedArtifacts
**/*.Server/ModelManifest.xml
_Pvt_Extensions

# Paket dependency manager
.paket/paket.exe
paket-files/

# FAKE - F# Make
.fake/

# CodeRush personal settings
.cr/personal

# Python Tools for Visual Studio (PTVS)
__pycache__/
*.pyc

# Cake - Uncomment if you are using it
# tools/**
# !tools/packages.config

# Tabs Studio
*.tss

# Telerik's JustMock configuration file
*.jmconfig

# BizTalk build output
*.btp.cs
*.btm.cs
*.odx.cs
*.xsd.cs

# OpenCover UI analysis results
OpenCover/

# Azure Stream Analytics local run output
ASALocalRun/

# MSBuild Binary and Structured Log
*.binlog

# NVidia Nsight GPU debugger configuration file
*.nvuser

# MFractors (Xamarin productivity tool) working folder
.mfractor/

# Local History for Visual Studio
.localhistory/

# Visual Studio History (VSHistory) files
.vshistory/

# BeatPulse healthcheck temp database
healthchecksdb

# Backup folder for Package Reference Convert tool in Visual Studio 2017
MigrationBackup/

# Ionide (cross platform F# VS Code tools) working folder
.ionide/

# Fody - auto-generated XML schema
FodyWeavers.xsd

# VS Code files for those working on multiple tools
.vscode/*
!.vscode/settings.json
!.vscode/tasks.json
!.vscode/launch.json
!.vscode/extensions.json
*.code-workspace

# Local History for Visual Studio Code
.history/

# Windows Installer files from build outputs
*.cab
*.msi
*.msix
*.msm
*.msp

# JetBrains Rider
*.sln.iml
````

{ collapsible="true" collapsed-title=".gitignore" }

**<path>.editorconfig</path>**

````
root = true

# All files
[*]
indent_style = space

# Xml files
[*.xml]
indent_size = 2

# C# files
[*.cs]

#### Core EditorConfig Options ####

# Indentation and spacing
indent_size = 4
tab_width = 4

# New line preferences
end_of_line = crlf
insert_final_newline = false

#### .NET Coding Conventions ####
[*.{cs,vb}]

# Organize usings
dotnet_separate_import_directive_groups = true
dotnet_sort_system_directives_first = true
file_header_template = unset

# this. and Me. preferences
dotnet_style_qualification_for_event = false:silent
dotnet_style_qualification_for_field = false:silent
dotnet_style_qualification_for_method = false:silent
dotnet_style_qualification_for_property = false:silent

# Language keywords vs BCL types preferences
dotnet_style_predefined_type_for_locals_parameters_members = true:silent
dotnet_style_predefined_type_for_member_access = true:silent

# Parentheses preferences
dotnet_style_parentheses_in_arithmetic_binary_operators = always_for_clarity:silent
dotnet_style_parentheses_in_other_binary_operators = always_for_clarity:silent
dotnet_style_parentheses_in_other_operators = never_if_unnecessary:silent
dotnet_style_parentheses_in_relational_binary_operators = always_for_clarity:silent

# Modifier preferences
dotnet_style_require_accessibility_modifiers = for_non_interface_members:silent

# Expression-level preferences
dotnet_style_coalesce_expression = true:suggestion
dotnet_style_collection_initializer = true:suggestion
dotnet_style_explicit_tuple_names = true:suggestion
dotnet_style_null_propagation = true:suggestion
dotnet_style_object_initializer = true:suggestion
dotnet_style_operator_placement_when_wrapping = beginning_of_line
dotnet_style_prefer_auto_properties = true:suggestion
dotnet_style_prefer_compound_assignment = true:suggestion
dotnet_style_prefer_conditional_expression_over_assignment = true:suggestion
dotnet_style_prefer_conditional_expression_over_return = true:suggestion
dotnet_style_prefer_inferred_anonymous_type_member_names = true:suggestion
dotnet_style_prefer_inferred_tuple_names = true:suggestion
dotnet_style_prefer_is_null_check_over_reference_equality_method = true:suggestion
dotnet_style_prefer_simplified_boolean_expressions = true:suggestion
dotnet_style_prefer_simplified_interpolation = true:suggestion

# Field preferences
dotnet_style_readonly_field = true:warning

# Parameter preferences
dotnet_code_quality_unused_parameters = all:suggestion

# Suppression preferences
dotnet_remove_unnecessary_suppression_exclusions = none

#### C# Coding Conventions ####
[*.cs]

# var preferences
csharp_style_var_elsewhere = false:silent
csharp_style_var_for_built_in_types = false:silent
csharp_style_var_when_type_is_apparent = false:silent

# Expression-bodied members
csharp_style_expression_bodied_accessors = true:silent
csharp_style_expression_bodied_constructors = false:silent
csharp_style_expression_bodied_indexers = true:silent
csharp_style_expression_bodied_lambdas = true:suggestion
csharp_style_expression_bodied_local_functions = false:silent
csharp_style_expression_bodied_methods = false:silent
csharp_style_expression_bodied_operators = false:silent
csharp_style_expression_bodied_properties = true:silent

# Pattern matching preferences
csharp_style_pattern_matching_over_as_with_null_check = true:suggestion
csharp_style_pattern_matching_over_is_with_cast_check = true:suggestion
csharp_style_prefer_not_pattern = true:suggestion
csharp_style_prefer_pattern_matching = true:silent
csharp_style_prefer_switch_expression = true:suggestion

# Null-checking preferences
csharp_style_conditional_delegate_call = true:suggestion

# Modifier preferences
csharp_prefer_static_local_function = true:warning
csharp_preferred_modifier_order = public,private,protected,internal,static,extern,new,virtual,abstract,sealed,override,readonly,unsafe,volatile,async:silent

# Code-block preferences
csharp_prefer_braces = true:silent
csharp_prefer_simple_using_statement = true:suggestion

# Expression-level preferences
csharp_prefer_simple_default_expression = true:suggestion
csharp_style_deconstructed_variable_declaration = true:suggestion
csharp_style_inlined_variable_declaration = true:suggestion
csharp_style_pattern_local_over_anonymous_function = true:suggestion
csharp_style_prefer_index_operator = true:suggestion
csharp_style_prefer_range_operator = true:suggestion
csharp_style_throw_expression = true:suggestion
csharp_style_unused_value_assignment_preference = discard_variable:suggestion
csharp_style_unused_value_expression_statement_preference = discard_variable:silent

# 'using' directive preferences
csharp_using_directive_placement = outside_namespace:silent

#### C# Formatting Rules ####

# New line preferences
csharp_new_line_before_catch = true
csharp_new_line_before_else = true
csharp_new_line_before_finally = true
csharp_new_line_before_members_in_anonymous_types = true
csharp_new_line_before_members_in_object_initializers = true
csharp_new_line_before_open_brace = all
csharp_new_line_between_query_expression_clauses = true

# Indentation preferences
csharp_indent_block_contents = true
csharp_indent_braces = false
csharp_indent_case_contents = true
csharp_indent_case_contents_when_block = true
csharp_indent_labels = one_less_than_current
csharp_indent_switch_labels = true

# Space preferences
csharp_space_after_cast = false
csharp_space_after_colon_in_inheritance_clause = true
csharp_space_after_comma = true
csharp_space_after_dot = false
csharp_space_after_keywords_in_control_flow_statements = true
csharp_space_after_semicolon_in_for_statement = true
csharp_space_around_binary_operators = before_and_after
csharp_space_around_declaration_statements = false
csharp_space_before_colon_in_inheritance_clause = true
csharp_space_before_comma = false
csharp_space_before_dot = false
csharp_space_before_open_square_brackets = false
csharp_space_before_semicolon_in_for_statement = false
csharp_space_between_empty_square_brackets = false
csharp_space_between_method_call_empty_parameter_list_parentheses = false
csharp_space_between_method_call_name_and_opening_parenthesis = false
csharp_space_between_method_call_parameter_list_parentheses = false
csharp_space_between_method_declaration_empty_parameter_list_parentheses = false
csharp_space_between_method_declaration_name_and_open_parenthesis = false
csharp_space_between_method_declaration_parameter_list_parentheses = false
csharp_space_between_parentheses = false
csharp_space_between_square_brackets = false

# Wrapping preferences
csharp_preserve_single_line_blocks = true
csharp_preserve_single_line_statements = true

#### Naming styles ####
[*.{cs,vb}]

# Naming rules

dotnet_naming_rule.types_and_namespaces_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.types_and_namespaces_should_be_pascalcase.symbols = types_and_namespaces
dotnet_naming_rule.types_and_namespaces_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.interfaces_should_be_ipascalcase.severity = suggestion
dotnet_naming_rule.interfaces_should_be_ipascalcase.symbols = interfaces
dotnet_naming_rule.interfaces_should_be_ipascalcase.style = ipascalcase

dotnet_naming_rule.type_parameters_should_be_tpascalcase.severity = suggestion
dotnet_naming_rule.type_parameters_should_be_tpascalcase.symbols = type_parameters
dotnet_naming_rule.type_parameters_should_be_tpascalcase.style = tpascalcase

dotnet_naming_rule.methods_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.methods_should_be_pascalcase.symbols = methods
dotnet_naming_rule.methods_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.properties_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.properties_should_be_pascalcase.symbols = properties
dotnet_naming_rule.properties_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.events_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.events_should_be_pascalcase.symbols = events
dotnet_naming_rule.events_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.local_variables_should_be_camelcase.severity = suggestion
dotnet_naming_rule.local_variables_should_be_camelcase.symbols = local_variables
dotnet_naming_rule.local_variables_should_be_camelcase.style = camelcase

dotnet_naming_rule.local_constants_should_be_camelcase.severity = suggestion
dotnet_naming_rule.local_constants_should_be_camelcase.symbols = local_constants
dotnet_naming_rule.local_constants_should_be_camelcase.style = camelcase

dotnet_naming_rule.parameters_should_be_camelcase.severity = suggestion
dotnet_naming_rule.parameters_should_be_camelcase.symbols = parameters
dotnet_naming_rule.parameters_should_be_camelcase.style = camelcase

dotnet_naming_rule.public_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.public_fields_should_be_pascalcase.symbols = public_fields
dotnet_naming_rule.public_fields_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.private_fields_should_be__camelcase.severity = suggestion
dotnet_naming_rule.private_fields_should_be__camelcase.symbols = private_fields
dotnet_naming_rule.private_fields_should_be__camelcase.style = _camelcase

dotnet_naming_rule.private_static_fields_should_be_s_camelcase.severity = suggestion
dotnet_naming_rule.private_static_fields_should_be_s_camelcase.symbols = private_static_fields
dotnet_naming_rule.private_static_fields_should_be_s_camelcase.style = s_camelcase

dotnet_naming_rule.public_constant_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.public_constant_fields_should_be_pascalcase.symbols = public_constant_fields
dotnet_naming_rule.public_constant_fields_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.private_constant_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.private_constant_fields_should_be_pascalcase.symbols = private_constant_fields
dotnet_naming_rule.private_constant_fields_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.public_static_readonly_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.public_static_readonly_fields_should_be_pascalcase.symbols = public_static_readonly_fields
dotnet_naming_rule.public_static_readonly_fields_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.private_static_readonly_fields_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.private_static_readonly_fields_should_be_pascalcase.symbols = private_static_readonly_fields
dotnet_naming_rule.private_static_readonly_fields_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.enums_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.enums_should_be_pascalcase.symbols = enums
dotnet_naming_rule.enums_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.local_functions_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.local_functions_should_be_pascalcase.symbols = local_functions
dotnet_naming_rule.local_functions_should_be_pascalcase.style = pascalcase

dotnet_naming_rule.non_field_members_should_be_pascalcase.severity = suggestion
dotnet_naming_rule.non_field_members_should_be_pascalcase.symbols = non_field_members
dotnet_naming_rule.non_field_members_should_be_pascalcase.style = pascalcase

# Symbol specifications

dotnet_naming_symbols.interfaces.applicable_kinds = interface
dotnet_naming_symbols.interfaces.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.interfaces.required_modifiers = 

dotnet_naming_symbols.enums.applicable_kinds = enum
dotnet_naming_symbols.enums.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.enums.required_modifiers = 

dotnet_naming_symbols.events.applicable_kinds = event
dotnet_naming_symbols.events.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.events.required_modifiers = 

dotnet_naming_symbols.methods.applicable_kinds = method
dotnet_naming_symbols.methods.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.methods.required_modifiers = 

dotnet_naming_symbols.properties.applicable_kinds = property
dotnet_naming_symbols.properties.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.properties.required_modifiers = 

dotnet_naming_symbols.public_fields.applicable_kinds = field
dotnet_naming_symbols.public_fields.applicable_accessibilities = public, internal
dotnet_naming_symbols.public_fields.required_modifiers = 

dotnet_naming_symbols.private_fields.applicable_kinds = field
dotnet_naming_symbols.private_fields.applicable_accessibilities = private, protected, protected_internal, private_protected
dotnet_naming_symbols.private_fields.required_modifiers = 

dotnet_naming_symbols.private_static_fields.applicable_kinds = field
dotnet_naming_symbols.private_static_fields.applicable_accessibilities = private, protected, protected_internal, private_protected
dotnet_naming_symbols.private_static_fields.required_modifiers = static

dotnet_naming_symbols.types_and_namespaces.applicable_kinds = namespace, class, struct, interface, enum
dotnet_naming_symbols.types_and_namespaces.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.types_and_namespaces.required_modifiers = 

dotnet_naming_symbols.non_field_members.applicable_kinds = property, event, method
dotnet_naming_symbols.non_field_members.applicable_accessibilities = public, internal, private, protected, protected_internal, private_protected
dotnet_naming_symbols.non_field_members.required_modifiers = 

dotnet_naming_symbols.type_parameters.applicable_kinds = namespace
dotnet_naming_symbols.type_parameters.applicable_accessibilities = *
dotnet_naming_symbols.type_parameters.required_modifiers = 

dotnet_naming_symbols.private_constant_fields.applicable_kinds = field
dotnet_naming_symbols.private_constant_fields.applicable_accessibilities = private, protected, protected_internal, private_protected
dotnet_naming_symbols.private_constant_fields.required_modifiers = const

dotnet_naming_symbols.local_variables.applicable_kinds = local
dotnet_naming_symbols.local_variables.applicable_accessibilities = local
dotnet_naming_symbols.local_variables.required_modifiers = 

dotnet_naming_symbols.local_constants.applicable_kinds = local
dotnet_naming_symbols.local_constants.applicable_accessibilities = local
dotnet_naming_symbols.local_constants.required_modifiers = const

dotnet_naming_symbols.parameters.applicable_kinds = parameter
dotnet_naming_symbols.parameters.applicable_accessibilities = *
dotnet_naming_symbols.parameters.required_modifiers = 

dotnet_naming_symbols.public_constant_fields.applicable_kinds = field
dotnet_naming_symbols.public_constant_fields.applicable_accessibilities = public, internal
dotnet_naming_symbols.public_constant_fields.required_modifiers = const

dotnet_naming_symbols.public_static_readonly_fields.applicable_kinds = field
dotnet_naming_symbols.public_static_readonly_fields.applicable_accessibilities = public, internal
dotnet_naming_symbols.public_static_readonly_fields.required_modifiers = readonly, static

dotnet_naming_symbols.private_static_readonly_fields.applicable_kinds = field
dotnet_naming_symbols.private_static_readonly_fields.applicable_accessibilities = private, protected, protected_internal, private_protected
dotnet_naming_symbols.private_static_readonly_fields.required_modifiers = readonly, static

dotnet_naming_symbols.local_functions.applicable_kinds = local_function
dotnet_naming_symbols.local_functions.applicable_accessibilities = *
dotnet_naming_symbols.local_functions.required_modifiers = 

# Naming styles

dotnet_naming_style.pascalcase.required_prefix = 
dotnet_naming_style.pascalcase.required_suffix = 
dotnet_naming_style.pascalcase.word_separator = 
dotnet_naming_style.pascalcase.capitalization = pascal_case

dotnet_naming_style.ipascalcase.required_prefix = I
dotnet_naming_style.ipascalcase.required_suffix = 
dotnet_naming_style.ipascalcase.word_separator = 
dotnet_naming_style.ipascalcase.capitalization = pascal_case

dotnet_naming_style.tpascalcase.required_prefix = T
dotnet_naming_style.tpascalcase.required_suffix = 
dotnet_naming_style.tpascalcase.word_separator = 
dotnet_naming_style.tpascalcase.capitalization = pascal_case

dotnet_naming_style._camelcase.required_prefix = _
dotnet_naming_style._camelcase.required_suffix = 
dotnet_naming_style._camelcase.word_separator = 
dotnet_naming_style._camelcase.capitalization = camel_case

dotnet_naming_style.camelcase.required_prefix = 
dotnet_naming_style.camelcase.required_suffix = 
dotnet_naming_style.camelcase.word_separator = 
dotnet_naming_style.camelcase.capitalization = camel_case

dotnet_naming_style.s_camelcase.required_prefix = s_
dotnet_naming_style.s_camelcase.required_suffix = 
dotnet_naming_style.s_camelcase.word_separator = 
dotnet_naming_style.s_camelcase.capitalization = camel_case


# Project Configurations

# SA1600: Elements should be documented
dotnet_diagnostic.SA1600.severity = none

# SA1602: Enum Elements should be documented
dotnet_diagnostic.SA1602.severity = none

# SA1633: File must have header
dotnet_diagnostic.SA1633.severity = none

# SA1101: Prefix local calls with this
dotnet_diagnostic.SA1101.severity = none

# SA1309: Field names should not begin with underscore
dotnet_diagnostic.SA1309.severity = none

#SA1516: Elements should be separated by blank line
dotnet_diagnostic.SA1516.severity = none

# SA1128: Put constructor initializers on their own line
dotnet_diagnostic.SA1128.severity = none

# SA1201: Elements should appear in the correct order
dotnet_diagnostic.SA1201.severity = none

# SA1204: Static elements should appear before instance elements
dotnet_diagnostic.SA1204.severity = none

# SA0001: XML comment analysis disabled
dotnet_diagnostic.SA0001.severity = none

# SA1118: Parameter should not span multiple lines
dotnet_diagnostic.SA1118.severity = none

# SA1601: Partial elements should be documented
dotnet_diagnostic.SA1601.severity = none

[**/Migrations/*]
generated_code = true
````

{ collapsible="true" collapsed-title=".editorconfig" }

> Diese Regeln können natürlich nach Belieben angepasst werden.

## Ordnerstruktur

Unser Programm teilen wir weiter auf in <path>src</path>, <path>tests</path> und <path>request</path>. Im <path>src</path> Ordner ist unser 
eigentliches Programm, im <path>tests</path> sind unsere Tests und im <path>requests</path> sind unsere HTTP-Requests.

`````
New-Item src -ItemType Directory
New-Item tests -ItemType Directory
New-Item requests -ItemType Directory
`````

## Projekte

Nun erstellen wir unsere Projekte und fügen die Abhängigkeiten hinzu.

````
Set-Location src
dotnet new webapi -o GymManagement.Api
dotnet new classlib -o GymManagement.Contracts
dotnet new classlib -o GymManagement.Application
dotnet new classlib -o GymManagement.Infrastructure
dotnet new classlib -o GymManagement.Domain

dotnet add .\GymManagement.Api\ reference .\GymManagement.Contracts\ .\GymManagement.Application\ .\GymManagement.Infrastructure\
dotnet add .\GymManagement.Infrastructure\ reference .\GymManagement.Application\
dotnet add .\GymManagement.Application\ reference .\GymManagement.Domain\

Set-Location ..
dotnet sln add (ls -r **\*.csproj)
````

Nun haben wir alles eingerichtet. Jetzt können wir noch die einzelnen generierten Dateien in den Klassenbibliotheken entfernen.

## Weitere Kleinigkeiten

### Projektdateien

In jedem `.csproj` File können wir die folgenden Zeilen entfernen, weil wir diese schon durch die <path>Directory.Build.Props</path> ersetzen:

````XML
<PropertyGroup>
  <TargetFramework>net8.0</TargetFramework>
  <ImplicitUsings>enable</ImplicitUsings>
  <Nullable>enable</Nullable>
</PropertyGroup>
````

Zudem können wir im Web API Projekt die beiden automatisch mitgelieferten NuGet-Pakete entfernen.

### Program.cs und Dependency Injection

Das <path>Program.cs</path> File ist überfüllt mit Dingen, die wir im Moment noch nicht brauchen. Deshalb entfernen wir das Meiste, sodass es am Schluss so aussieht:

````C#
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
````

Dafür fügen wir aber eine weitere Datei im Web API Projekt hinzu, <path>DependencyInjection.cs</path>, so stellen wir sicher, dass unser 
<path>Program.cs</path> nicht zu überfüllt ist mit Registrierungen aus anderen Layern und wir eine klare Verteilung haben. Für mehr Informationen 
siehe [**Dependency Injection**](Dependency-Injection.md).

````C#
namespace GymManagement.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }
}
````