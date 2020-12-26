using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.LEGO.Game;

namespace Unity.LEGO.UI
{
    public class ObjectiveHUDManager : MonoBehaviour
    {
        [Header("References")]

        [SerializeField, Tooltip("The UI panel containing the layoutGroup for displaying objectives.")]
        RectTransform m_ObjectivePanel = default;

        [SerializeField, Tooltip("The prefab for winning objectives.")]
        GameObject m_WinObjectivePrefab = default;

        [SerializeField, Tooltip("The prefab for losing objectives.")]
        GameObject m_LoseObjectivePrefab = default;

        const int s_TopMartin = 10;
        const int s_Spacing = 10;
        float m_NextY;

        List<IObjective> m_Objectives;

        protected void Awake()
        {
            m_Objectives = new List<IObjective>();

            EventManager.AddListener<ObjectiveAdded>(OnObjectiveAdded);
        }

        void OnObjectiveAdded(ObjectiveAdded evt)
        {
            m_Objectives.Add(evt.Objective);

            if (!evt.Objective.m_Hidden)
            {
                // Instanciate the UI element for the new objective.
                GameObject go = Instantiate(evt.Objective.m_Lose ? m_LoseObjectivePrefab : m_WinObjectivePrefab, m_ObjectivePanel.transform);

                // Initialise the objective element.
                Objective objective = go.GetComponent<Objective>();
                objective.Initialize(evt.Objective.m_Title, evt.Objective.m_Description, evt.Objective.GetProgress());

                // Force layout rebuild to get height of objectiveUI.
                LayoutRebuilder.ForceRebuildLayoutImmediate(objective.GetComponent<RectTransform>());

                // Position the objective.
                var rectTransform = go.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(0, m_NextY - s_TopMartin);
                m_NextY -= rectTransform.sizeDelta.y + s_Spacing;

                evt.Objective.OnProgress += objective.OnProgress;
            }
        }

        void OnDestroy()
        {
            EventManager.RemoveListener<ObjectiveAdded>(OnObjectiveAdded);
        }
    }
}
