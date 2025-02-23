import { Grid2 } from "@mui/material";
import ActivityList from "./ActivityList";
import ActivityDetail from "./details/ActivityDetail";
import ActivityForm from "../form/ActivityForm";

type Props = {
    activities: Activity[]
    selectActivity: (id: string) => void;
    cancelSelectActivity: () => void;
    selectedActivity: Activity | undefined;
    openForm: (id: string) => void;
    closeForm: () => void;
    editMode: boolean
    submitForm: (activity: Activity) => void;
    deleteActivity: (id: string) => void;
}

export default function ActivityDashboard({
    activities,
    cancelSelectActivity,
    deleteActivity,
    selectActivity,
    selectedActivity,
    openForm,
    closeForm,
    editMode,submitForm,
}: Props) {
    return (
        <Grid2 container spacing={3}>
            <Grid2 size={9}>
                <ActivityList
                    activities={activities}
                    selectActivity={selectActivity}
                    deleteActivity={deleteActivity}
                />
            </Grid2>
            <Grid2 size={5}>
                {selectedActivity &&
                    <ActivityDetail
                        activity={selectedActivity}
                        cancelSelectActivity={cancelSelectActivity}
                        openForm={openForm}
                    />
                }
                {editMode &&
                    <ActivityForm closeForm={closeForm} submitForm={submitForm} activity={selectedActivity}/>}
            </Grid2>
        </Grid2>
    )
}
