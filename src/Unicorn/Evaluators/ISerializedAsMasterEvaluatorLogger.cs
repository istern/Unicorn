﻿using System;
using Rainbow.Model;

namespace Unicorn.Evaluators
{
	public interface ISerializedAsMasterEvaluatorLogger
	{
		/// <summary>
		/// Called when an item is evaluated for deletion
		/// </summary>
		void RecycledItem(IItemData deletedItem);
		
		/// <summary>
		/// Fired when an item's name is different between serialized and source
		/// </summary>
		void Renamed(IItemData sourceItem, IItemData targetItem);

		/// <summary>
		/// Fired when an item's template is different between serialized and source
		/// </summary>
		void TemplateChanged(IItemData sourceItem, IItemData targetItem);

		/// <summary>
		/// Fired when a shared field value is different between serialized and source
		/// </summary>
		/// <remarks>Note that the sourceValue may be null</remarks>
		void SharedFieldIsChanged(IItemData targetItem, Guid fieldId, string targetValue, string sourceValue);

		/// <summary>
		/// Fired when a version's field value is different between serialized and source
		/// </summary>
		/// <remarks>Note that the sourceValue may be null</remarks>
		void VersionedFieldIsChanged(IItemData targetItem, IItemVersion version, Guid fieldId, string targetValue, string sourceValue);

		/// <summary>
		/// Fired when a later version is found in the serialized version of an item
		/// </summary>
		void NewTargetVersion(IItemVersion newSerializedVersion, IItemData serializedItemData, IItemData existingItemData);

		/// <summary>
		/// Called when you serialize an item that does not yet exist in the provider
		/// </summary>
		void DeserializedNewItem(IItemData targetItem);

		/// <summary>
		/// Called when you serialize an updated item that already existed in the provider
		/// </summary>
		void SerializedUpdatedItem(IItemData targetItem);

		/// <summary>
		/// Called when extra versions exist in a source item compared to the serialized version
		/// </summary>
		void OrphanSourceVersion(IItemData existingItemData, IItemData serializedItemData, IItemVersion[] orphanSourceVersions);

		/// <summary>
		/// Called when an item is evaluated regardless of the result (deleted, added, same, changed, etc)
		/// </summary>
		void Evaluated(IItemData item);
	}
}
