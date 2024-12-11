# 项目

## 概述

本项目主要演示Blazor组件通信的四种方式：组件参数、级联值和参数、事件回调以及状态容器。

## 项目结构

ComponentCommunication.Client
	|- Pages
		|- ParameterDisplay
		|- CascadingParameterDisplay
		|- EventCallbackDisplay
		|- StateContainerDisplay
ComponentCommunication.Server
ComponentCommunication.Shared
	|- ObjectBase.cs
	|- Player.cs