using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ads {

	public interface Partner {

		int priority { get;}

        bool Ready(PLACEMENT type);
        IEnumerator Play(PLACEMENT type);
    }
    
}
