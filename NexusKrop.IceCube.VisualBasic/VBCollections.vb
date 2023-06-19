' Copyright (C) 2023 NexusKrop & contributors
'
' Licensed under the Apache License, Version 2.0 (the "License");
' you may not use this file except in compliance with the License.
' You may obtain a copy of the License at
'
'    http://www.apache.org/licenses/LICENSE-2.0
'
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' See the License for the specific language governing permissions And
' limitations under the License.

Imports NexusKrop.IceCube.Collections

''' <summary>
''' Provides utilities to create collections.
''' </summary>
Public Module VBCollections
    ''' <inheritdoc cref="List.Of(Of T)(T())"/>
    Public Function ListOf(Of T)(ParamArray values() As T) As IList(Of T)
        Return List.Of(values)
    End Function

    ''' <summary>
    ''' Creates an array of <typeparamref name="T"/> consisting of the specified <paramref name="values"/>.
    ''' </summary>
    ''' <typeparam name="T">The type of the array to create.</typeparam>
    ''' <param name="values">The single value of the array.</param>
    ''' <returns>The created array consisting of the values specified.</returns>
    Public Function ArrayOf(Of T)(ParamArray values() As T) As T()
        Return values
    End Function
End Module
