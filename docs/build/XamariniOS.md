---
title: Xamarin iOS Build Template
description: Template for building a Xamarin iOS application
author: Nick Randolph
---

# Xamarin iOS Build Template

Use this template to build iOS applications from a Visual Studio Solution file (ie Xamarin).

## YAML snippet

```yaml
# Xamarin iOS Build Template
# Template for building a Xamarin iOS application
stages:
- template:  azure/mobile/build-xamarin-ios.yml@builttoroam_templates
  parameters:
    solution_filename:
    ios_provisioning_profile_securefiles_filename:
    ios_cert_securefiles_filename:
    #stage_name:  # Optional
    #depends_on:  # Optional
    #build_ios_enabled:  # Optional 
    #build_number:  # Optional 
    #full_version_number:  # Optional 
    #solution_build_configuration:  # Optional 
    #ios_plist_filename:  # Optional 
    #ios_cert_password:  # Optional 
    #ios_signing_identity:  # Optional 
    #ios_provisioning_profile_id:  # Optional 
    #artifact_name:  # Optional 
    #artifact_folder:  # Optional
    #application_package:  # Optional
    #onStart:  # Optional 
    #preBuild:  # Optional 
    #postBuild:  # Optional 
    #prePublish:  # Optional 
    #onEnd:  # Optional 
    #nuget_version:  # Optional
    #net_core_version:  # Optional
    #xamarin_sdk_version:  # Optional
```


## Arguments

<table><thead><tr><th>Argument</th><th>Description</th></tr></thead>

<tr><td>stage_name</td><td>(Optional) The name of the stage, so that it can be referenced elsewhere (eg for dependsOn property). Defaults to 'Build_iOS'</td></tr>
<tr><td>depends_on</td><td>(Optional) The array of stages that this stage depends on. Default is that this stage does not depend on any other stage</td></tr>
<tr><td>build_ios_enabled</td><td>(Optional) Whether this stages should be executed. Note that setting this to false won't completely cancel the stage, it will merely skip most of the stages. The stage will appear to complete successfully, so any stages that depend on this stage will attempt to execute</td></tr>
<tr><td>build_number</td><td>(Optional) The build number to be applied to the application. Defaults to Build.BuildId built in variable</td></tr>
<tr><td>full_version_number</td><td>(Optional) The full application version number. Defaults to 1.0.XXX where XXX is the same as the build_number</td></tr>
<tr><td>solution_filename</td><td>(Required) The relative path to the solution file that should be built</td></tr>
<tr><td>solution_build_configuration</td><td>(Optional) The build configuration within the solution that should be invoked. Default is Release but can be overwritten if you want to do say a Debug build</td></tr>
<tr><td>ios_plist_filename</td><td>(Optional) The Info.plist file that contains the application information such as bundle id and version information. If not specified, template will locate the first Info.plist automatically.</td></tr>
<tr><td>ios_cert_securefiles_filename</td><td>(Required) The certificate file used to sign the application. This is the name of the certificate in Secure Files</td></tr>
<tr><td>ios_cert_password</td><td>(Optional) The password to unlock the certificate so it can be used. This is required if the certificate has a password set</td></tr>
<tr><td>ios_provisioning_profile_securefiles_filename</td><td>(Required) The provisioning profile to use when signing the application. This is the name of the provisioning profile in Secure Files</td></tr>
<tr><td>ios_signing_identity</td><td>(Optional) The signing identity that maps to the signing certificate. If not provided, the template will use the value extracted during the certificate installation process.</td></tr>
<tr><td>ios_provisioning_profile_id</td><td>(Optional) The id of the provisioning profile. If not provided, the template will use the value extracted during the installation of the provisioning profile</td></tr>
<tr><td>artifact_name</td><td>(Optional) The name of the artifact to copy application to</td></tr>
<tr><td>artifact_folder</td><td>(Optional) The name of the folder to copy application to in the artifact</td></tr>
<tr><td>application_package</td><td>(Optional) The name of the application package to output</td></tr>
<tr><td>onStart</td><td>(Optional) Steps to be executed before stage starts</td></tr>
<tr><td>preBuild</td><td>(Optional) Steps to be executed before the build starts</td></tr>
<tr><td>postBuild</td><td>(Optional) Steps to be executed after the build has been invoked</td></tr>
<tr><td>prePublish</td><td>(Optional) Steps to be executed before application package is published to artifact</td></tr>
<tr><td>onEnd</td><td>(Optional) Steps to be executed at the end of the stage</td></tr>
<tr><td>nuget_version</td><td>(Optional) Use to override the NuGet version (defaults to 4.4.1)</td></tr>
<tr><td>net_core_version</td><td>(Optional) Use to override the .NET Core version (defaults to 3.0.x)</td></tr>
<tr><td>xamarin_sdk_version</td><td>(Optional) Use to override the Xamarin SDK version (defaults to 6.4.0)</td></tr>


</table>

## Open source

This template is open source [on GitHub](https://github.com/builttoroam/pipeline_templates). Feedback and contributions are welcome.
