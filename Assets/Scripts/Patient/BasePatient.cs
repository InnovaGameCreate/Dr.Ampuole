using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patient
{
    public abstract class BasePatient : MonoBehaviour
    {
        protected abstract PatientType patientType { get; }
    }
}