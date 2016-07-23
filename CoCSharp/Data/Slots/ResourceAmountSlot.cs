﻿using CoCSharp.Data.Models;
using CoCSharp.Network;
using System;

namespace CoCSharp.Data.Slots
{
    /// <summary>
    /// Represents a Clash of clans resource amount slot.
    /// </summary>
    public class ResourceAmountSlot : Slot<ResourceData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAmountSlot"/> class.
        /// </summary>
        public ResourceAmountSlot()
        {
            // Space
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAmountSlot"/> class with the
        /// specified resource ID and amount.
        /// </summary>
        /// <param name="id">ID of the resource.</param>
        /// <param name="amount">Amount of the resource.</param>
        public ResourceAmountSlot(int id, int amount)
        {
            ID = id;
            Amount = amount;
        }

        private int _id;
        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_instance.InvalidDataID(value))
                    throw new ArgumentOutOfRangeException("value", _instance.GetArgsOutOfRangeMessage("value"));

                _id = value;
            }
        }

        /// <summary>
        /// Gets or sets the amount of resources.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Reads the <see cref="ResourceAmountSlot"/> from the specified <see cref="MessageReader"/>.
        /// </summary>
        /// <param name="reader">
        /// <see cref="MessageReader"/> that will be used to read the <see cref="ResourceAmountSlot"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="reader"/> is null.</exception>
        public override void ReadSlot(MessageReader reader)
        {
            ThrowIfReaderNull(reader);

            ID = reader.ReadInt32();
            Amount = reader.ReadInt32();
        }

        /// <summary>
        /// Writes the <see cref="ResourceAmountSlot"/> to the specified <see cref="MessageWriter"/>.
        /// </summary>
        /// <param name="writer">
        /// <see cref="MessageWriter"/> that will be used to write the <see cref="ResourceAmountSlot"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="writer"/> is null.</exception>
        public override void WriteSlot(MessageWriter writer)
        {
            ThrowIfWriterNull(writer);

            writer.Write(ID);
            writer.Write(Amount);
        }
    }
}
